using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_readFiles
{
    public class Results
    {
        public string fileName;
        public bool results_sorted;
        public int size;
        public TimeSpan bucket_sort;
        public TimeSpan insertion_sort;
        public TimeSpan selection_sort;
        public TimeSpan bubble_sort;
        public TimeSpan merge_sort;
        public TimeSpan quick_sort;

        public Results(string fileName, bool results_sorted, int size, TimeSpan bucket, TimeSpan insertion, TimeSpan selection, TimeSpan bubble, TimeSpan merge, TimeSpan quick)
        {
            this.fileName = fileName;
            this.results_sorted = results_sorted;
            this.size = size;
            this.bucket_sort = bucket;
            this.insertion_sort = insertion;
            this.selection_sort = selection;
            this.bubble_sort = bubble;
            this.merge_sort = merge;
            this.quick_sort = quick;
        }

    }
}
