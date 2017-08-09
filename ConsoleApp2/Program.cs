using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class DataFile
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }
        public override string ToString()
        {
            return String.Format("\t{0}\n\t\tExtension: {1}\n\t\tSize: {2}\n", Name, Extension, Size);
        }
    }

    class TextFile : DataFile
    {
        public string Content { get; set; }
        public override string ToString()
        {
            return base.ToString() + String.Format("\t\tContent: {0}\n", Content);
        }
    }

    class MediaFile : DataFile
    {
        public string Resolution { get; set; }
        public override string ToString()
        {
            return base.ToString() + String.Format("\t\tResolution: {0}\n", Resolution);
        }
    }

    class ImageFile : MediaFile
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }

    class VideoFile : MediaFile
    {
        public string Duration { get; set; }
        public override string ToString()
        {
            return base.ToString() + String.Format("\t\tDuration: {0}\n", Duration);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String inputString = (@"Text: file.txt(6B); Some string content
Image: img.bmp(19MB); 1920x1080
Text:data.txt(12B); Another string
Text:data1.txt(7B); Yet another string
Movie:logan.2017.mkv(19GB); 1920x1080; 2h12m");
            String[] str = inputString.Split('\n');
            DataFile[] obj = new DataFile[10];
            int index = 0;

            foreach (var name in str)
            {
                String[] words = name.Trim('\r').Split(new[] { ':', '(', ')', ';' }, StringSplitOptions.RemoveEmptyEntries);
                switch (words[0])
                {
                    case "Text":
                        TextFile tf = new TextFile();
                        tf.Name = words[1].Trim();
                        tf.Extension = tf.Name.Split('.').Last();
                        tf.Size = words[2].Trim();
                        tf.Content = words[3].Trim();
                        obj[index++] = tf;
                        break;
                    case "Image":
                        ImageFile imgf = new ImageFile();
                        imgf.Name = words[1].Trim();
                        imgf.Extension = imgf.Name.Split('.').Last();
                        imgf.Size = words[2].Trim();
                        imgf.Resolution = words[3].Trim();
                        obj[index++] = imgf;
                        break;
                    case "Movie":
                        VideoFile vf = new VideoFile();
                        vf.Name = words[1].Trim();
                        vf.Extension = vf.Name.Split('.').Last();
                        vf.Size = words[2].Trim();
                        vf.Resolution = words[3].Trim();
                        vf.Duration = words[4].Trim();
                        obj[index++] = vf;
                        break;
                    default:
                        break;
                }
            }
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(obj[i]);
            }
        }
    }
}