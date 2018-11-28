using System.IO;
using System.Windows.Forms;
using TagCloud.TagCloudVisualization.Analyzer;
using TagCloud.Words;

namespace TagCloud.Actions
{
    public class LoadWordsAction : IUiAction
    {
        private readonly Words.Words words;

        public LoadWordsAction(Words.Words words)
        {
            this.words = words;
        }

        public string Category => "File";
        public string Name => "Tag Words";
        public string Description => "Load file with Tag Words";

        public void Perform()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                var fileStream = openFileDialog.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    var fileContent = reader.ReadToEnd();
                    var splittedWords = WordAnalyzer.SplitWords(fileContent);
                    words.Load(splittedWords);
                }
            }

        }
    }



}