using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAnalysis
{
    class Sorting
    {
        public static int[] mergeArrays(int[] arr1, int[] arr2)
        {
            int i = 0, j = 0, k = 0, n1 = arr1.Length,n2 = arr2.Length;
            int[] arr3 = new int[n1 + n2];
            // Traverse both array 
            while (i < n1 && j < n2)
            {
                if (arr1[i] < arr2[j])
                    arr3[k++] = arr1[i++];
                else
                    arr3[k++] = arr2[j++];
            }

            // Store remaining  
            // elements of first array 
            while (i < n1)
                arr3[k++] = arr1[i++];

            // Store remaining elements 
            // of second array 
            while (j < n2)
                arr3[k++] = arr2[j++];

            return arr3;
        }
        public static void BubbleSort(int[] arr, int n)
        {

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap arr[j+1] and arr[j] 
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

        }

        public static void bubbleSort(int[] arr, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                   (arr[i],arr[i+1]) = (arr[i+1],arr[i]);
                }
            }
            if (n - 1 > 1)
            {
                bubbleSort(arr, n - 1);
            }
        }
        public static void BubbleSortRecursive(int[] arr, int n)
        {
            // Base case 
            if (n == 1)
                return;

            // One pass of bubble  
            // sort. After this pass, 
            // the largest element 
            // is moved (or bubbled)  
            // to end. 
            bool swaped = false;
            for (int i = 0; i < n - 1; i++)
                if (arr[i] > arr[i + 1])
                {
                    (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                    swaped = true;
                }

            // Largest element is fixed, 
            // recur for remaining array 
            if (swaped == true)
                BubbleSortRecursive(arr, n - 1);
        }
        public static void InsertionSort(int[] arr, int n)
        {
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1], 
                // that are greater than key, 
                // to one position ahead of 
                // their current position 
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        public static void InsertionSortRecursive(int[] arr, int n)
        {
            // Base case 
            if (n <= 1)
                return;

            // Sort first n-1 elements 
            InsertionSortRecursive(arr, n - 1);

            // Insert last element at  
            // its correct position 
            // in sorted array. 
            int last = arr[n - 1];
            int j = n - 2;

            /* Move elements of arr[0..i-1],  
            that are greater than key, to  
            one position ahead of their 
            current position */
            while (j >= 0 && arr[j] > last)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = last;
        }

        /* This function takes last element as pivot, 
        places the pivot element at its correct 
        position in sorted array, and places all 
        smaller (smaller than pivot) to left of 
        pivot and all greater elements to right 
        of pivot */
        private static int PartitionForQuickSort(int[] arr, int low,
                                       int high)
        {
            int pivot = arr[high];

            // index of smaller element 
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                // If current element is smaller  
                // than the pivot 
                if (arr[j] < pivot)
                {
                    i++;

                    // swap arr[i] and arr[j] 
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);

            return i + 1;
        }

        public static void QuickSortRecursive(int[] arr, int n)
        {
            QuickSortRecursive(arr, 0, n - 1);
        }

        /* The main function that implements QuickSort() 
        arr[] --> Array to be sorted, 
        low --> Starting index, 
        high --> Ending index */
        private static void QuickSortRecursive(int[] arr, int low, int high)
        {
            if (low < high)
            {

                /* pi is partitioning index, arr[pi] is  
                now at right place */
                int pi = PartitionForQuickSort(arr, low, high);

                // Recursively sort elements before 
                // partition and after partition 
                QuickSortRecursive(arr, low, pi - 1);
                QuickSortRecursive(arr, pi + 1, high);
            }
        }

        public static void QuickSort(int[] arr, int n)
        {
            QuickSort(arr, 0, n - 1);
        }
        private static void QuickSort(int[] arr, int l, int h)
        {
            // Create an auxiliary stack 
            int[] stack = new int[h - l + 1];

            // initialize top of stack 
            int top = -1;

            // push initial values of l and h to 
            // stack 
            stack[++top] = l;
            stack[++top] = h;

            // Keep popping from stack while 
            // is not empty 
            while (top >= 0)
            {
                // Pop h and l 
                h = stack[top--];
                l = stack[top--];

                // Set pivot element at its 
                // correct position in 
                // sorted array 
                int p = PartitionForQuickSort(arr, l, h);

                // If there are elements on 
                // left side of pivot, then 
                // push left side to stack 
                if (p - 1 > l)
                {
                    stack[++top] = l;
                    stack[++top] = p - 1;
                }

                // If there are elements on 
                // right side of pivot, then 
                // push right side to stack 
                if (p + 1 < h)
                {
                    stack[++top] = p + 1;
                    stack[++top] = h;
                }
            }
        }

        private static void Merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two subarrays to be merged 
            int n1 = m - l + 1;
            int n2 = r - m;

            /* Create temp arrays */
            int[] L = new int[n1];
            int[] R = new int[n2];

            /*Copy data to temp arrays*/
            int i, j;
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            /* Merge the temp arrays */
           
            // Initial indexes of first and second subarrays 
            i = 0; j = 0;

            // Initial index of merged subarry array 
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            /* Copy remaining elements of L[] if any */
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            /* Copy remaining elements of R[] if any */
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that sorts arr[l..r] using 
        // merge() 
        public static void MergeSortRecursive(int[] arr, int n)
        {
            MergeSortRecursive(arr, 0, n - 1);
        }
        private static void MergeSortRecursive(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle point 
                int m = (l + r) / 2;

                // Sort first and second halves 
                MergeSortRecursive(arr, l, m);
                MergeSortRecursive(arr, m + 1, r);

                // Merge the sorted halves 
                Merge(arr, l, m, r);
            }
        }


        


    }
}
