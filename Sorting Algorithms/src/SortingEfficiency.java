import java.util.*;

public class SortingEfficiency {

	public void swap(int index1, int index2, int[] list) {
		// System.out.println("Swapping indices: " + index1 + " " + index2);
		int temp = list[index1];
		list[index1] = list[index2];
		list[index2] = temp;
	}

	// regular bubble sort
	public int[] bubbleSortPlain(int[] list) {
		int temp;
		int comparisons = 0;
		int swaps = 0;

		for (int i = 0; i < list.length - 1; i++) {
			for (int j = 1; j < list.length - i; j++) {
				comparisons++;
				if (list[j - 1] > list[j]) {
					swap(j - 1, j, list);
					swaps++;
				}
			}
		}
		System.out.println("Bubble Sort Plain \nComparisons: " + comparisons
				+ "\nSwaps: " + swaps + "\nSorted: " + sortCheck(list));
		return list;
	}

	// Early stop bubble sort
	public int[] bubbleSortStopEarly(int[] list) {
		int temp;
		int comparisons = 0;
		int swaps = 0;
		boolean isSorted = false;

		for (int i = 0; i < list.length - 1; i++) {
			isSorted = true;
			for (int j = 1; j < list.length - i; j++) {
				comparisons++;
				if (list[j - 1] > list[j]) {
					swap(j - 1, j, list);
					swaps++;
					isSorted = false;
				}
			}
			if (isSorted) {
				break;
			}
		}
		System.out.println("Bubble Sort Early Stop\nComparisons: "
				+ comparisons + "\nSwaps: " + swaps + "\nSorted: "
				+ sortCheck(list));
		return list;
	}

	// Alternating SHaker Sort
	public int[] shakerSort(int[] list) {

		boolean swapped = false;
		int comparisons = 0;
		int swaps = 0;
		int j;
		int start = -1;
		int end = list.length;
		while (start < end) {
			start++;
			end--;
			swapped = false;
			for (j = start; j < end; j++) {
				comparisons++;
				if (list[j] > list[j + 1]) {
					swap(j, j + 1, list);
					swaps++;
					swapped = true;
				}
			}
			if (!swapped) {
				break;
			}
			for (j = end; --j >= start;) {
				comparisons++;
				if (list[j + 1] < list[j]) {
					swap(j, j + 1, list);
					swaps++;
					swapped = true;
				}
			}
			if (!swapped) {
				break;
			}
		}
		System.out.println("Shaker Sort \nComparisons: " + comparisons
				+ "\nSwaps: " + swaps + "\nSorted: " + sortCheck(list));
		return list;
	}

	// insertion sort with swaps
	public int[] insertionSortSwaps(int[] list, int start, int end, boolean outFlag) {
		int comparisons = 0;
		int swaps = 0;

		for (int i = start+1; i <= end; i++) {
			for (int j = i; j > 0; j--) {
				comparisons++;
				if (list[j - 1] > list[j]) {
					swap(j - 1, j, list);
					swaps++;
				}
			}
		}
		if(outFlag){
		System.out.println("Insertion Sort w/Swap\nComparisons: " + comparisons
				+ "\nSwaps: " + swaps + "\nSorted: " + sortCheck(list));
		}
		return list;
	}

	// insertion sort with shifts
	public int[] insertionSortShifts(int[] list, int start, int end, boolean outFlag) {
		int comparisons = 0;
		int shifts = 0;
		if (end - start > 1) {
			for (int i = start + 1; i <= end; i++) {
				int current = list[i];
				int pointer = i - 1;
				while (pointer >= 0 && current < list[pointer]) {
					list[pointer + 1] = list[pointer];
					pointer--;
					shifts++;
					comparisons++;
				}
				comparisons++;
				list[pointer + 1] = current;
				shifts++;
			}
			if(outFlag){
			  System.out .println("Insertion Sort Shift\nComparisons: " +
			  comparisons + "\nShifts: " + shifts + "\nSorted: " +
			  sortCheck(list) );
			} 
		}
		int[] swapsAndComps = { comparisons, shifts };
		return swapsAndComps;
	}

	// insertion sort with binary search
	public int[] insertionSortBinary(int[] list) {
		int comparisons = 0;
		int shifts = 0;
		for (int i = 1; i < list.length; i++) {
			int current = list[i];
			int pointer = i - 1;
			comparisons++;
			if (current < list[pointer]) {
				int insert = Math.abs(Arrays.binarySearch(list, 0, pointer,
						current) + 1);
				int temp = i;
				while (temp > insert && temp > 0) {
					list[temp] = list[temp - 1];
					shifts++;
					temp--;
					comparisons++;
				}
				shifts++;
				list[insert] = current;
			}
		}
		System.out.println("Insertion Sort w/Binary Search\nComparisons: "
				+ comparisons + "\nShifts: " + shifts + "\nSorted: "
				+ sortCheck(list));
		return list;
	}

	// selection sort
	public int[] selectionSort(int[] list, int start, int end, boolean outFlag) {
		int swaps = 0;
		int comps = 0;
		if (end - start > 1) {
			for (int i = start; i <= end; i++) {
				int min = list[i];
				int minIndex = i;
				for (int k = i + 1; k <= end; k++) {
					comps++;
					if (list[k] < min) {
						min = list[k];
						minIndex = k;
					}
				}
				comps++;
				if (list[i] != list[minIndex]) {
					swaps++;
					swap(i, minIndex, list);
				}
			}
			if(outFlag){
			System.out.println("Selection Sort\nComparisons: " + comps
					+ "\nSwaps: " + swaps + "\nSorted: " + sortCheck(list));
			}		
		}
		
		int[] swapsAndComps = {swaps, comps};
		return swapsAndComps;
	}

	int rec = 0;
	int copies = 0;
	int mergeComps = 0;

	// merge sort
	public void mergeSort(int[] data, int first, int n) {
		int n1; // start of the first half of the array
		int n2; // start of the second half of the array
		if (n > 1) {
			// Compute start of the two halves
			n1 = n / 2;
			n2 = n - n1;
			rec = rec + 2;
			mergeSort(data, first, n1); // Sort data[first] through
										// data[first+n1-1]
			mergeSort(data, first + n1, n2); // Sort data[first+n1] to the end
			// Merge the two sorted halves.
			merge(data, first, n1, n2);
		}
	}

	public void merge(int[] data, int first, int n1, int n2) {
		int[] temp = new int[n1 + n2]; // Allocate the temporary array
		int copied = 0; // Number of elements copied from data to temp
		int copied1 = 0; // Number copied from the first half of data
		int copied2 = 0; // Number copied from the second half of data
		int i; // Array index to copy from temp back into data
		
		// Merge elements, copying from two halves of data to the temporary
		// array.
		while ((copied1 < n1) && (copied2 < n2)) {
			mergeComps++;
			if (data[first + copied1] < data[first + n1 + copied2]) {
				temp[copied++] = data[first + (copied1++)];
				copies++;
			} else {
				temp[copied++] = data[first + n1 + (copied2++)];
				copies++;
			}
		}
		// Copy any remaining entries in the left and right subarrays.
		while (copied1 < n1) {
			temp[copied++] = data[first + (copied1++)];
			copies++;
		}
		while (copied2 < n2) {
			temp[copied++] = data[first + n1 + (copied2++)];
			copies++;
		}
		// Copy from temp back to the data array.
		for (i = 0; i < n1 + n2; i++) {
			data[first + i] = temp[i];
			copies++;
		}
	}

	int quickSwaps = 0;
	int quickComps = 0;
	int quickRecCalls = 0;
	public void quickSort(int[] list, int start, int end) {
		this.quickSortPlain(list, start, end);
		System.out.println("Quicksort\nSwaps: " + quickSwaps
				+ "\nRecurstartve Calls: " + quickRecCalls + "\nComparisons: "
				+ quickComps);
	}
	public void quickSortPlain(int[] list, int start, int end) {
		// base case
		if (end <= start || start >= end) {
		}
		else {
			int pivot = list[start];
			int i = start + 1;
			int tmp;

			// partition array
			for (int j = start + 1; j <= end; j++) {
				quickComps++;
				if (pivot > list[j]) {
					this.swap(i, j, list);
					quickSwaps++;
					i++;
				}
			}
			// put pivot in right partition
			list[start] = list[i - 1];
			list[i - 1] = pivot;

			
			quickRecCalls++;
			quickSortPlain(list, start, i - 2);

			quickRecCalls++;
			quickSortPlain(list, i, end);
		}
	}

	int quickSortMedianOfThreeComparisons = 0;
	int quickSortMedianOfThreeSwaps = 0;
	int quickSortMedianOfThreeRecurstartveCalls = 0;

	public void quickSortMed(int[] list, int start, int end) {
		this.quickSortMedianOfThree(list, start, end);
		System.out.println("Quicksort with median\nSwaps: "
				+ quickSortMedianOfThreeSwaps + "\nRecurstartve Calls: "
				+ quickSortMedianOfThreeRecurstartveCalls + "\nComparisons: "
				+ quickSortMedianOfThreeComparisons);
	}

	public void quickSortMedianOfThree(int[] list, int start, int end) {
		if (start < end) {
			int first = list[start];
			int middle = list[(start + end) / 2];
			int last = list[end];
			int p = start;
			if (middle <= first && middle >= last) {
				p = (start + end) / 2;
			} else if (middle >= first && middle <= last) {
				p = (start + end) / 2;
			} else if (last >= first && last <= middle) {
				p = end;
			} else if (last <= first && last >= middle) {
				p = end;
			}
			int pivot = list[p];
			int i = start;
			int j = end;
			while (i != j) {
				quickSortMedianOfThreeComparisons++;
				if (list[i] < pivot) {
					i++;
				} else {
					quickSortMedianOfThreeSwaps++;
					list[j] = list[i];
					list[i] = list[j - 1];
					j--;
				}
			}
			list[j] = pivot;
			quickSortMedianOfThreeRecurstartveCalls++;
			quickSortMedianOfThree(list, start, j - 1);

			quickSortMedianOfThreeRecurstartveCalls++;
			quickSortMedianOfThree(list, j + 1, end);
		}
	}

	int selswaps = 0;
	int selcomps = 0;
	int selrec = 0;

	public void quickSortSelection(int[] list, int start, int end) {
		this.quickSortSel(list, start, end);
		System.out.println("Quicksort with Selection\nSwaps: " + selswaps
				+ "\nRecurstartve Calls: " + selrec + "\nComparisons: "
				+ selcomps);
	}

	public void quickSortSel(int[] list, int start, int end) {
		int n = end - start;
		if (n <= 20) {			
			int[] swapsAndComps = this.selectionSort(list, start, end, false);
			selswaps += swapsAndComps[0];
			selcomps += swapsAndComps[1];
		} else {
			// base case
			if (end <= start || start >= end) {
			}

			else {
				int pivot = list[start];
				int i = start + 1;
				int tmp;

				// partition array
				for (int j = start + 1; j <= end; j++) {
					selcomps++;
					if (pivot > list[j]) {
						this.swap(i, j, list);
						selswaps++;
						i++;
					}
				}
				// put pivot in right postarttion
				list[start] = list[i - 1];
				list[i - 1] = pivot;

				// call qsort on right and left startdes of pivot
				selrec++;
				quickSortSel(list, start, i - 2);

				selrec++;
				quickSortSel(list, i, end);
			}
		}
	}

	int qSwaps = 0;
	int qComps = 0;
	int qRec = 0;

	public void quickSortInsertion(int[] list, int start, int end) {
		this.quickSortInsert(list, start, end);
		System.out.println("Quicksort with Insertion\nSwaps: " + qSwaps
				+ "\nRecurstartve Calls: " + qRec + "\nComparisons: " + qComps);
	}

	public void quickSortInsert(int[] list, int start, int end) {
		int n = end - start;
		if (n <= 20) {
			int[] compsAndSwaps = this.insertionSortShifts(list, start, end, false);
			qSwaps += compsAndSwaps[1];
			qComps += compsAndSwaps[0];
		} else {
			// base case
			if (end <= start || start >= end) {
			}

			else {
				int pivot = list[start];
				int i = start + 1;
				int tmp;

				// partition array
				for (int j = start + 1; j <= end; j++) {
					qComps++;
					if (pivot > list[j]) {
						this.swap(i, j, list);
						qSwaps++;
						i++;
					}
				}
				// put pivot in right postarttion
				list[start] = list[i - 1];
				list[i - 1] = pivot;

				// call qsort on right and left startdes of pivot
				qRec++;
				quickSortInsert(list, start, i - 2);

				qRec++;
				quickSortInsert(list, i, end);
			}
		}
	}

	/*-------------------------UTILITIES------------------------------*/
	// print array
	public void printList(int[] list) {
		String temp = "";
		for (int s : list) {
			temp += s + " ";
		}
		System.out.println(temp);
	}

	// makes an array of integers of specified startze and data range
	public int[] makeRandomArray(int startze, int range) {
		Random r = new Random();
		int[] list = new int[startze];
		for (int i = 0; i < startze; i++) {
			// ints from 0-99
			list[i] = r.nextInt(range);
		}
		return list;
	}

	// see if the list is sorted
	public boolean sortCheck(int[] list) {
		boolean b = false;
		int i = 0;
		while (list[i + 1] >= list[i] && i < list.length - 2) {
			i++;
		}
		if (i == list.length - 2)
			b = true;
		return b;
		// System.out.println("List Sorted?  " + b + "\n");
	}

	public static void main(String[] args) {
		SortingEfficiency s = new SortingEfficiency();
		int[] list = s.makeRandomArray(100, 1000);// {6,2,1,44,9,7,8,3,0,11};
		int[] list2 = list.clone();
		int[] list3 = list.clone();
		int[] list4 = list.clone();
		int[] list5 = list.clone();
		int[] list6 = list.clone();
		int[] list7 = list.clone();
		int[] list8 = list.clone();
		int[] list9 = list.clone();
		int[] list11 = list.clone();
		int[] list12 = list.clone();
		int[] list10 = list.clone();
		
		
		long startTime = 0;
		long endTime = 0;
		
		startTime = System.nanoTime();
		s.bubbleSortPlain(list);
		endTime = System.nanoTime();
		System.out.println("Time Taken: " + (endTime - startTime)+ "\n");
		
		startTime = System.nanoTime();
		s.bubbleSortStopEarly(list2);
		endTime = System.nanoTime();
		System.out.println("Time Taken: " + (endTime - startTime)+ "\n");
		
		startTime = System.nanoTime();
		s.shakerSort(list3);
		endTime = System.nanoTime();
		System.out.println("Time Taken: " + (endTime - startTime)+ "\n");
		
		
		startTime = System.nanoTime();
		s.insertionSortSwaps(list4, 0, list4.length-1, true);
		endTime = System.nanoTime();
		System.out.println("Time Taken: " + (endTime - startTime)+ "\n");
		
		startTime = System.nanoTime();
		s.insertionSortShifts(list5, 0 ,list5.length-1, true);
		endTime = System.nanoTime();
		System.out.println("Time Taken: " + (endTime - startTime)+ "\n");
		
		
		startTime = System.nanoTime();
		s.insertionSortBinary(list6);
		endTime = System.nanoTime();
		System.out.println("Time Taken: " + (endTime - startTime)+ "\n");
		
		
		startTime = System.nanoTime();
		s.selectionSort(list7, 0, list.length - 1, true);
		endTime = System.nanoTime();
		System.out.println("Time Taken: " + (endTime - startTime)+ "\n");


		startTime = System.nanoTime();
		s.mergeSort(list8, 0, list.length);
		 System.out.println("Merge Sort\nRecursive Calls: " +s.rec +
		 "\nCopies: " +s.copies + "\nSorted: " + s.sortCheck(list8) + "\n" + "Comparisons: " + s.mergeComps);
		endTime = System.nanoTime();
		System.out.println("Time Taken: " + (endTime - startTime) + "\n");
		
		
		startTime = System.nanoTime();
		s.quickSort(list9, 0, list9.length - 1);
		System.out.println(s.sortCheck(list9));
		endTime = System.nanoTime();
		System.out.println("Time Taken: " + (endTime - startTime)+ "\n");

		startTime = System.nanoTime();
		s.quickSortMed(list10, 0, list10.length - 1);
		System.out.println(s.sortCheck(list10));
		endTime = System.nanoTime();
		System.out.println("Time Taken: " + (endTime - startTime)+ "\n");

		startTime = System.nanoTime();
		s.quickSortSelection(list11, 0, list11.length - 1);
		System.out.println(s.sortCheck(list11));
		endTime = System.nanoTime();
		System.out.println("Time Taken: " + (endTime - startTime)+ "\n");

		startTime = System.nanoTime();
		s.quickSortInsertion(list12, 0, list12.length - 1);
		System.out.println(s.sortCheck(list12));
		endTime = System.nanoTime();
		System.out.println("Time Taken: " + (endTime - startTime)+ "\n");
	}

}
