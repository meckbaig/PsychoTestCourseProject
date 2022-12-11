﻿using PsychoTestCourseProject.Extensions;
using PsychoTestCourseProject.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PsychoTestCourseProject.ViewModel
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public string Picture { get; set; } 
        public Thickness Margin { get; set; }
        public TestViewModel(TestClass test)
        {
            Supporting.CurrentTest = test;
            Supporting.CurrentQuestion = 0;
            Picture = Path.GetDirectoryName(test.Filename)+"/"+test.Name+".jpg";
        }

        public QuestionClass CurrentQuestion
        {
            get => Supporting.CurrentTest.Questions[Supporting.CurrentQuestion];
        }


        public QuestionClass NextQuestion()
        {
            if (Supporting.CurrentQuestion == (Supporting.CurrentTest.Questions.Count - 1))
            {
                return null;
            }
            return Supporting.CurrentTest.Questions[++Supporting.CurrentQuestion];
        }

        public void ChangeQuestionMargin(double width, double height)
        {
            Margin = new Thickness(width / 10, height / 15, width / 10, height / 15);
            OnPropertyChanged("Margin");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        //public QuestionClass PreviousQuestion()
        //{
        //    if (idQuestion == 0)
        //    {
        //        return null;
        //    }
        //    return Supporting.CurrentTest.Questions[--idQuestion];
        //}
    }
}
