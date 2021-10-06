using System;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Windows;

namespace VoiceSpeaker
{
    public class Speaker
    {
        private static Task task = null;

        public static string EN { get; private set; } = "en-US";
        public static string RU { get; private set; } = "ru-RU";

        public static Task Say(string message, bool isEnglish = true)
        {
            if (task != null)
            {
                if (task.Status == TaskStatus.Running)
                {
                    task.Wait();
                }
            }

            return task = Task.Factory.StartNew(() =>
            {
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();

                speechSynthesizer.Volume = 100;
                speechSynthesizer.Rate = -2;

                if (isEnglish == false)
                {
                    var voice = speechSynthesizer.GetInstalledVoices();

                    foreach (InstalledVoice item in voice)
                    {
                        if (item.VoiceInfo.Culture.Name == RU)
                        {
                            speechSynthesizer.SelectVoice(item.VoiceInfo.Name);
                        }
                    }
                }
                else
                {
                    var voice = speechSynthesizer.GetInstalledVoices();

                    foreach (InstalledVoice item in voice)
                    {
                        if (item.VoiceInfo.Culture.Name == EN && item.VoiceInfo.Name == "Microsoft David Desktop")
                        {
                            speechSynthesizer.SelectVoice(item.VoiceInfo.Name);
                        }
                    }
                }

                speechSynthesizer.SpeakAsync(message);
            });
        }

        public static void GetSaying()
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo(EN));

            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
            recognizer.LoadGrammar(new DictationGrammar());

            try
            {
                recognizer.SetInputToDefaultAudioDevice();
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                MessageBox.Show("It is no default audio device. To detail info check error log.");
                Tools.ErrorLogSave(ex.ToString());
                return;
            }
        }

        private static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text.ToLower();

            if (result.Contains("hello"))
            {
                MainWindow.voiceWindow.lbOutput.Items.Add("Hi i am also glad to speak with you.");
                Say("Hi i am also glad to speak with you.");
                return;
            }

            MainWindow.voiceWindow.lbTestOutput.Content = e.Result.Text;
        }
    }
}
