﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Shaolin_Kung_Fu.Common;

namespace Shaolin_Kung_Fu
{
    class Student
    {
        private BitmapImage _profilePicture;


        public string Name { get; set; }
        public int Id { get; set; }

        public int Team { get; set; }

        public byte[] Image { get; set; }

        public BitmapImage ProfilePicture
        {
            get
            {
                if (Image != null)
                {
                   return ConvertImg();
                }
                return null;
            }
            private set { _profilePicture = value; }
        }

        public Student(string name, int id)
        {
            Name = name;
            Id = id;
            
        }

        public BitmapImage ConvertImg()
        {
            var handler = new ImageConversionHandler();
           return handler.Convert(Image);
        }
    }
}
