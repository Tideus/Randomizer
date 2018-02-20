using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using TagLib;


namespace PlayGen
{

    class ConrolFolder
    {

        #region Field 

        UIControl uiControl = null; // экземпляр элемента управления папкой

        List<UIControl> boxControls = new List<UIControl>(); // коллекция экземпляров управления папками

        ToolStripLabel timeCount = null; // подсчет суммарного времени

        Random rnd = new Random(DateTime.Now.Millisecond);

        TimeSpan duration = new TimeSpan(); // переменная для длительности песен

        TimeSpan hours = new TimeSpan(); // пороговое значение времени

        int count = 0; //число папок на экране

        int k = 0; // счетчик валидных директорий

        int[] memory = null; // массив для хранения индекса возобновления генерации с последнего трека

        int[] memoryDir = null; // массив для хранения индекса возобновления генерации с последней директории

        int progressing = 0; // начальное значение прогресс бара

        bool exit = false; //флаг прерывания

        object block = new object(); // объект синхронизации      

        #endregion

        public void GenConrol(StartForm startForm)
        {
            if (PlayGen.Properties.Settings.Default.ToOpenFolders)
            {
                GenConrol_24Hour_OpenFolder(startForm);
            }
            else
            {
                GenConrol_24Hour_CloseFolder(startForm);
            }
        }

        void GenConrol_24Hour_OpenFolder(StartForm startForm)
        {

            startForm.Panel.BackgroundImage = null;

            progressing = 0;
            startForm.Invoke(new MethodInvoker(() => startForm.ProgressBar.Value = 0));

            DirectoryInfo[] dirArr = startForm.PathInfo.GetDirectories(); // получаю поддиректории

            if (dirArr.Length == 0)
            {
                startForm.Invoke(new MethodInvoker(() => startForm.ProgressBar.Value = 0));
                return;
            }

            int value = dirArr.Length; // количество поддиректорий

            lock (block)
            {
                for (int i = count; i < count + value; i++)
                {
                    startForm.Panel.Invoke(new MethodInvoker(() =>
                    {
                        uiControl = new UIControl();
                        uiControl.DirectoryMix.Visible = false;

                        // 
                        // TextBox Folfer
                        //
                        uiControl.TextBoxFolder.Name = "textBox" + i.ToString();
                        uiControl.TextBoxFolder.Text = dirArr[i - count].FullName.ToString();

                        // 
                        // NumericMinutes
                        // 
                        uiControl.NumericMinutes.Name = "numericMinutes" + i.ToString();
                        uiControl.NumericMinutes.Value = 0;
                        uiControl.NumericMinutes.ValueChanged += Time_ValueChanged;
                        uiControl.NumericMinutes.Tag = k;

                        // 
                        // NumericHours
                        // 
                        uiControl.NumericHours.Name = "numericHours" + i.ToString();
                        uiControl.NumericHours.Value = 0;
                        uiControl.NumericHours.ValueChanged += Time_ValueChanged;
                        uiControl.NumericHours.Tag = k;

                        // 
                        // CountLabel MaxDuration Tracks
                        // 
                        uiControl.MaxTime.Name = "maxTimeLabel" + i.ToString();

                        DirectoryInfo pathInfo = new DirectoryInfo(uiControl.TextBoxFolder.Text);

                        // string[] extensions = new[] { ".mp3", ".wav", ".flac" };
                        string[] extensions = Settings.GetAudioFormat();

                        FileInfo[] trackArray = pathInfo.GetFiles("*.*", SearchOption.AllDirectories)
                                 .Where(f => extensions.Contains(f.Extension.ToLower()))
                                 .ToArray();

                        duration = TimeSpan.Zero;

                        for (int y = 0; y < trackArray.Length; y++)
                        {
                            try
                            {
                                var audioFile = TagLib.File.Create(trackArray[y].FullName.ToString(), TagLib.ReadStyle.Average);
                                duration += audioFile.Properties.Duration;
                            }
                            catch (CorruptFileException)
                            {
                                continue;
                                //todo: сделать запись в логи                              
                            }

                            catch (PathTooLongException)
                            {
                                DialogResult result = MessageBox.Show("Фаил или директория\n\n" + trackArray[y].FullName.ToString() + "\n\n Имеет слишком длинный путь или имя файла. Полное имя файла должно содержать меньше 260 знаков, а имя каталога - меньше 248", "Ошибка! Пропустить?", MessageBoxButtons.YesNo);

                                if (result == DialogResult.Yes)
                                {
                                    y = trackArray.Length;
                                    i = count + value;
                                    startForm.ProgressBar.Value = 100;
                                    break;
                                }
                                else
                                {
                                    y = trackArray.Length;
                                    Application.Restart();
                                }
                            }
                        }
                        uiControl.MaxTime.Text = "/" + duration.ToString("dd\\:hh\\:mm\\:ss");
                        uiControl.MaxTime.ForeColor = System.Drawing.Color.Red;

                        // 
                        // ChekBox Shuffle Tracks
                        // 
                        uiControl.TrackMix.Name = "innerShuffle" + i.ToString();

                        // 
                        //ADDControls
                        //
                        if (uiControl.MaxTime.Text != "/00:00:00:00")
                        {
                            // 
                            // NumberLabel
                            //
                            uiControl.NumerLabel.Name = "label" + i.ToString();
                            uiControl.NumerLabel.Text = (k + 1).ToString();
                            k++;

                            boxControls.Add(uiControl);
                            startForm.Panel.Controls.Add(uiControl);

                            progressing++;
                            startForm.ProgressBar.Value = (progressing * 100 / value);
                        }
                        else
                        {
                            progressing++;
                            startForm.ProgressBar.Value = (progressing * 100 / value);
                        }
                    }));
                }

                // 
                // Label timeCount
                //   
                if (timeCount == null) timeCount = startForm.TimeCount;

                count = boxControls.Count;
                progressing = 0;
            }
        }

        void GenConrol_24Hour_CloseFolder(StartForm startForm)
        {
            startForm.Panel.BackgroundImage = null;

            progressing = 0;

            startForm.Invoke(new MethodInvoker(() => startForm.ProgressBar.Value = 0));

            DirectoryInfo patch = startForm.PathInfo; //получаем директорию

            DirectoryInfo[] dirArr = patch.GetDirectories(); //получаем массив поддиректорий

            if (dirArr.Length == 0)
            {
                startForm.Invoke(new MethodInvoker(() => startForm.ProgressBar.Value = 100));

                return;
            }

            lock (block)
            {
                startForm.Panel.Invoke(new MethodInvoker(() =>
                {
                    uiControl = new UIControl();

                    // 
                    // TextBox Folfer
                    //
                    uiControl.TextBoxFolder.Name = "textBox" + k.ToString();
                    uiControl.TextBoxFolder.Text = patch.FullName.ToString();

                    // 
                    // NumericMinutes
                    // 
                    uiControl.NumericMinutes.Name = "numericMinutes" + k.ToString();
                    uiControl.NumericMinutes.Value = 0;
                    uiControl.NumericMinutes.ValueChanged += Time_ValueChanged;
                    uiControl.NumericMinutes.Tag = k;

                    // 
                    // NumericHours
                    // 
                    uiControl.NumericHours.Name = "numericHours" + k.ToString();
                    uiControl.NumericHours.Value = 0;
                    uiControl.NumericHours.ValueChanged += Time_ValueChanged;
                    uiControl.NumericHours.Tag = k;

                    // 
                    // CountLabel MaxDuration Tracks
                    // 
                    uiControl.MaxTime.Name = "maxTimeLabel" + k.ToString();

                    duration = TimeSpan.Zero; // сбрасываем время

                    string[] extensions = Settings.GetAudioFormat();
                    //string[] extensions = new[] { ".mp3", ".wav", ".flac" };

                    for (int i = 0; i < dirArr.Length; i++)
                    {
                        FileInfo[] trackArray = dirArr[i].GetFiles("*.*", SearchOption.AllDirectories)
                             .Where(f => extensions.Contains(f.Extension.ToLower()))
                             .ToArray(); // получаем файлы для каждой папки

                        for (int y = 0; y < trackArray.Length; y++)
                        {
                            try
                            {
                                var audioFile = TagLib.File.Create(trackArray[y].FullName.ToString(), TagLib.ReadStyle.Average);
                                duration += audioFile.Properties.Duration;
                            }
                            catch (CorruptFileException)
                            {
                                continue;
                                //todo: сделать запись в логи                              
                            }

                            catch (PathTooLongException)
                            {
                                DialogResult result = MessageBox.Show("Фаил или директория\n\n" + trackArray[y].FullName.ToString() + "\n\n Имеет слишком длинный путь или имя файла. Полное имя файла должно содержать меньше 260 знаков, а имя каталога - меньше 248", "Ошибка! Пропустить?", MessageBoxButtons.YesNo);

                                if (result == DialogResult.Yes)
                                {
                                    y = trackArray.Length;
                                    i = count;
                                    startForm.ProgressBar.Value = 100;
                                    break;
                                }
                                else
                                {
                                    y = trackArray.Length;
                                    Application.Restart();
                                }
                            }
                        }

                        progressing++;
                        startForm.ProgressBar.Value = (progressing * 100 / dirArr.Length);
                    }

                    uiControl.MaxTime.Text = "/" + duration.ToString("dd\\:hh\\:mm\\:ss"); //TODO: Сделать удобное читабельное время

                    uiControl.MaxTime.ForeColor = System.Drawing.Color.Red;

                    // 
                    // ChekBox Shuffle Tracks
                    // 
                    uiControl.TrackMix.Name = "innerShuffle" + k.ToString();

                    // 
                    //ADDControls
                    //
                    if (uiControl.MaxTime.Text != "/00:00:00:00")
                    {
                        // 
                        // NumberLabel
                        //
                        uiControl.NumerLabel.Name = "label" + k.ToString();
                        uiControl.NumerLabel.Text = (k + 1).ToString();
                        k++;

                        boxControls.Add(uiControl);
                        startForm.Panel.Controls.Add(uiControl);

                        //todo: здесь должен быть прогресс, реализован неверно
                        // progressing++;
                        // progress.Report(progressing * 100 / count);
                    }
                    else
                    {
                        // progressing++;
                        // progress.Report(progressing * 100 / count);
                    }
                }));

                // 
                // Label timeCount
                //   
                if (timeCount == null) timeCount = startForm.TimeCount;

                count = boxControls.Count;
                progressing = 0;
            }
        }

        bool TotalPercent(int index)
        {
            decimal sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += boxControls[i].NumericHours.Value * 60 + boxControls[i].NumericMinutes.Value;
            }

            if (sum <= 1440)
            {
                timeCount.Text = String.Format("{0}:{1}", (int)(sum / 60), sum - (int)(sum / 60) * 60);
                return true;
            }
            else
            {
                DialogResult result = MessageBox.Show("Total Time can not be more than 24 hour!\n\nAdd the required time?", "Error!", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    sum = 0;
                    for (int i = 0; i < count; i++)
                    {
                        if (i == index)
                        {
                            continue;
                        }
                        sum += boxControls[i].NumericHours.Value * 60 + boxControls[i].NumericMinutes.Value;
                    }
                    decimal newsum = 1440 - sum;
                    boxControls[index].NumericHours.Value = (int)(newsum / 60);
                    boxControls[index].NumericMinutes.Value = newsum - (int)(newsum / 60) * 60;
                }

                else
                {
                    boxControls[index].NumericHours.Value = 0;
                    boxControls[index].NumericMinutes.Value = 0;
                }

                return false;
            }
        }

        void Time_ValueChanged(object sender, EventArgs e)
        {
            int i = int.Parse(((NumericUpDown)sender).Tag.ToString());

            if (boxControls[i].NumericMinutes.Value == 60)
            {
                boxControls[i].NumericMinutes.Value = 0;

                if (boxControls[i].NumericHours.Value != 23)
                {
                    boxControls[i].NumericHours.Value++;
                }
            }

            if (!TotalPercent(i))
            {
                boxControls[i].BackColor = System.Drawing.Color.White; // цвет сброса               
            }

            if (boxControls[i].NumericMinutes.Value + boxControls[i].NumericHours.Value == 0)

                boxControls[i].BackColor = System.Drawing.Color.White; // цвет сброса
            else
                boxControls[i].BackColor = System.Drawing.Color.PaleGoldenrod; // цвет зафиксированного значения
        }

        public void GenTrackMode(StartForm startForm)
        {
            if (startForm.Mode == 0)
            {
                if (PlayGen.Properties.Settings.Default.ToOpenFolders)
                {
                    GenTrack_24Hour_OpenFolder(startForm);
                }
                else
                {
                    GenTrack_24Hour_CloseFolder(startForm);
                }

            }
            else
            {
                //GenTrack_Single(); 
                //todo: Сделать режим
            }
        }

        public void GenTrack_24Hour_OpenFolder(StartForm startForm)
        {

            memory = new int[count]; // запоминаем место продолжения генерации
            progressing = 1;
            startForm.Invoke(new MethodInvoker(() => startForm.ProgressBar.Value = 0));

            //очищаем плейлист
            for (int z = 0; z < startForm.TabPlaylist.TabCount; z++)
            {
                startForm.Invoke((MethodInvoker)(() => startForm.TabPlaylist.TabPages[z].Controls.OfType<System.Windows.Forms.TextBox>().First().Clear()));
            }

            List<UIControl> tempBox = new List<UIControl>(); // временный лист

            if (startForm.BlockShuffle) // блоковая генерация
            {
                tempBox.AddRange(boxControls); //добавляем контролы во временный лист
                boxControls = boxControls.OrderBy(x => rnd.Next()).ToList(); //перемешать контролы в боксконтролс
            }

            for (int z = 0; z < startForm.TabPlaylist.TabCount; z++)
            {
                for (int i = 0; i < count; i++)
                {
                    if (boxControls[i].NumericHours.Value != 0 || boxControls[i].NumericMinutes.Value != 0)
                    {
                        DirectoryInfo pathInfo = new DirectoryInfo(boxControls[i].TextBoxFolder.Text);


                        //string[] extensions = new[] { ".mp3", ".wav", ".flac" };
                        string[] extensions = Settings.GetAudioFormat();


                        FileInfo[] trackArray = pathInfo.GetFiles("*.*", SearchOption.AllDirectories)
                                 .Where(f => extensions.Contains(f.Extension.ToLower()))
                                 .ToArray();

                        duration = new TimeSpan((int)boxControls[i].NumericHours.Value, (int)boxControls[i].NumericMinutes.Value, 0);
                        hours = TimeSpan.Zero;

                        if (boxControls[i].TrackMix.Checked)
                        {
                            trackArray = trackArray.OrderBy(x => rnd.Next()).ToArray();
                            Algorithm_Unchecked(trackArray, startForm, z, i);
                        }
                        else
                        {
                            Algorithm_Unchecked(trackArray, startForm, z, i);
                        }
                    }
                }

                if (startForm.AllShuffle)
                {
                    List<string> split = new List<string>(startForm.TabPlaylist.TabPages[z].Controls.OfType<System.Windows.Forms.TextBox>().First().Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
                    startForm.Invoke((MethodInvoker)(() => startForm.TabPlaylist.TabPages[z].Controls.OfType<System.Windows.Forms.TextBox>().First().Clear()));
                    int count = split.Count;

                    for (int i = 0; i < count; i++)
                    {
                        int randomNumber = rnd.Next(split.Count);
                        startForm.Invoke((MethodInvoker)(() => startForm.TabPlaylist.TabPages[z].Controls.OfType<System.Windows.Forms.TextBox>().First().Text += split[randomNumber] + "\r\n"));
                        split.RemoveAt(randomNumber);
                    }
                }

                startForm.Invoke(new MethodInvoker(() =>
                {
                    startForm.ProgressBar.Value = (progressing * 100 / 7);
                    startForm.ProgressLabel.Text = startForm.ProgressBar.Value.ToString() + " %";
                    progressing++;
                }));
            }

            if (startForm.BlockShuffle)
            {
                boxControls = tempBox;
            }
        }

        private void Algorithm_Unchecked(FileInfo[] trackArray, StartForm startForm, int numerTab, int i)
        {
            for (int j = memory[i]; j < trackArray.Length; j++)
            {
                startForm.Invoke((MethodInvoker)(() => startForm.TabPlaylist.TabPages[numerTab].Controls.OfType<System.Windows.Forms.TextBox>().First().Text += trackArray[j].FullName.ToString() + Environment.NewLine));

                try
                {
                    var audioFile = TagLib.File.Create(trackArray[j].FullName.ToString(), TagLib.ReadStyle.Average);
                    hours += audioFile.Properties.Duration;
                }
                catch (CorruptFileException)
                {
                    continue;
                    //todo: сделать запись в логи                              
                }

                if (hours >= duration)
                {
                    memory[i] = j + 1;

                    if (memory[i] == trackArray.Length)
                    {
                        memory[i] = 0;
                    }
                    break;
                }
                if (hours < duration && j == trackArray.Length - 1)
                {
                    memory[i] = 0;
                    Algorithm_Unchecked(trackArray, startForm, numerTab, i);
                }
            }
        }

        public void GenTrack_24Hour_CloseFolder(StartForm startForm)
        {

            memory = new int[count]; // запоминаем место продолжения генерации трека
            memoryDir = new int[count]; // запоминаем папку 

            progressing = 1;
            startForm.Invoke(new MethodInvoker(() => startForm.ProgressBar.Value = 0));

            //очищаем плейлист
            for (int z = 0; z < startForm.TabPlaylist.TabCount; z++)
            {
                startForm.TabPlaylist.Invoke(new MethodInvoker(() => startForm.TabPlaylist.TabPages[z].Controls.OfType<System.Windows.Forms.TextBox>().First().Clear()));
            }

            List<UIControl> tempBox = new List<UIControl>(); // временный лист

            if (startForm.BlockShuffle) // блоковая генерация
            {
                tempBox.AddRange(boxControls); //добавляем контролы во временный лист
                boxControls = boxControls.OrderBy(x => rnd.Next()).ToList(); //перемешать контролы в боксконтролс
            }

            for (int z = 0; z < startForm.TabPlaylist.TabCount; z++) // пробегаемся по всем листам плейлиста
            {
                
                
                for (int i = 0; i < count; i++) // пробегаемся по контролам на панели
                {                   

                    if (boxControls[i].NumericHours.Value != 0 || boxControls[i].NumericMinutes.Value != 0)
                    {

                        DirectoryInfo pathInfo = new DirectoryInfo(boxControls[i].TextBoxFolder.Text); // получаем путь к корневой папке

                        DirectoryInfo[] dirArr = pathInfo.GetDirectories(); // получаем поддиректории корневой папки

                        if (boxControls[i].DirectoryMix.Checked)
                        {
                            dirArr = dirArr.OrderBy(x => rnd.Next()).ToArray();
                        }

                        duration = new TimeSpan((int)boxControls[i].NumericHours.Value, (int)boxControls[i].NumericMinutes.Value, 0);
                        hours = TimeSpan.Zero;

                        Algorithm_Unchecked_CloseFolder(dirArr, startForm, z, i, i); // алгоритм генерации
                    }
                }

                if (startForm.AllShuffle)
                {
                    List<string> split = new List<string>(startForm.TabPlaylist.TabPages[z].Controls.OfType<System.Windows.Forms.TextBox>().First().Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
                    startForm.Invoke((MethodInvoker)(() => startForm.TabPlaylist.TabPages[z].Controls.OfType<System.Windows.Forms.TextBox>().First().Clear()));

                    int count = split.Count; // количество треков для рандома

                    for (int i = 0; i < count; i++)
                    {
                        int randomNumber = rnd.Next(split.Count);
                        startForm.Invoke((MethodInvoker)(() => startForm.TabPlaylist.TabPages[z].Controls.OfType<System.Windows.Forms.TextBox>().First().Text += split[randomNumber] + "\r\n"));
                        split.RemoveAt(randomNumber);
                    }
                }

                startForm.Invoke(new MethodInvoker(() =>
                {
                    startForm.ProgressBar.Value = (progressing * 100 / 7);
                    startForm.ProgressLabel.Text = startForm.ProgressBar.Value.ToString() + " %";
                    progressing++;
                }));
            }

            if (startForm.BlockShuffle)
            {
                boxControls = tempBox;
            }
        }

        private void Algorithm_Unchecked_CloseFolder(DirectoryInfo[] dirArr, StartForm startForm, int numerTab, int i, int memoryIndex)
        {          

            for (int z = memoryDir[memoryIndex]; z < dirArr.Length; z++) // пробегаемся по подпапкам корневой папки
            {
               
                string[] extensions = Settings.GetAudioFormat();

                FileInfo[] trackArray = dirArr[z].GetFiles("*.*", SearchOption.AllDirectories)
                            .Where(f => extensions.Contains(f.Extension.ToLower()))
                            .ToArray();

                if (trackArray.Length == 0)
                {
                    memoryDir[memoryIndex] = z + 1;

                    if (memoryDir[memoryIndex] == dirArr.Length)
                    {
                        memoryDir[memoryIndex] = 0;
                    }
                    Algorithm_Unchecked_CloseFolder(dirArr, startForm, numerTab, i, memoryIndex);
                }


                if (boxControls[i].TrackMix.Checked)
                {
                    trackArray = trackArray.OrderBy(x => rnd.Next()).ToArray();
                }

                for (int j = memory[i]; j < trackArray.Length; j++)
                {                   
                   
                    startForm.Invoke((MethodInvoker)(() => startForm.TabPlaylist.TabPages[numerTab].Controls.OfType<System.Windows.Forms.TextBox>().First().Text += trackArray[j].FullName.ToString() + Environment.NewLine));

                    try
                    {
                        var audioFile = TagLib.File.Create(trackArray[j].FullName.ToString(), TagLib.ReadStyle.Average);
                        hours += audioFile.Properties.Duration;
                    }
                    catch (CorruptFileException)
                    {
                        continue;
                        //todo: сделать запись в логи                              
                    }

                    if (hours >= duration)
                    {
                        memory[i] = j + 1;
                        memoryDir[memoryIndex] = z;

                        if (memory[i] == trackArray.Length)
                        {
                            memory[i] = 0;
                            memoryDir[memoryIndex] = z + 1;
                        }

                        if (memoryDir[memoryIndex] == dirArr.Length)
                        {
                            memoryDir[memoryIndex] = 0;
                        }                      
                        return;
                    
                    }

                    if (hours < duration && j == trackArray.Length - 1)
                    {
                        memory[i] = 0;
                        memoryDir[memoryIndex] = z + 1;

                        if (memoryDir[memoryIndex] == dirArr.Length)
                        {
                            memoryDir[memoryIndex] = 0;
                        }
                        Algorithm_Unchecked_CloseFolder(dirArr, startForm, numerTab, i, memoryIndex);                      
                    }
                }
            }          
        }

        public void Clear(StartForm startForm)
        {
            boxControls.Clear(); //очищаем лист с элементами
            count = 0; // сброс подсчета элементов
            k = 0; //сброс счета валидных папок
            timeCount = null; //сброс времени
            progressing = 1; //прогресс по умолчанию
            startForm.ProgressLabel.Text = "Ready"; // сброс текста прогресса           
            startForm.Panel.Controls.Clear(); //очищаем панель

            for (int z = 0; z < startForm.TabPlaylist.TabCount; z++) // очистка плейлиста на форме
            {
                startForm.TabPlaylist.TabPages[z].Controls.OfType<System.Windows.Forms.TextBox>().First().Clear();
            }
            startForm.Panel.BackgroundImage = Properties.Resources.drag; // возвращаем фоновое изображение
        }
    }
}