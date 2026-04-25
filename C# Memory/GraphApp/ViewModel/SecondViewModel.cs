using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphApp.ViewModel.Abstract;

namespace GraphApp.ViewModel
{
    internal class SecondViewModel : ISecondViewModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
	}
}
