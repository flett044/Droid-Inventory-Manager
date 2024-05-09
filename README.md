## Description
This software serves as a comprehensive management system for Star Wars droids utilized by a shipping company. The system is pre-loaded with eight test droids, featuring two of each type. Users have the capability to add droids by type and customize various options associated with each droid. The program offers sorting functionality based on two criteria: model and total cost.

Sorting by model employs a bucket sort algorithm. Droids are removed from their respective stacks and enqueued onto a droid queue. The original droid array is then updated with the sorted droids.

For sorting by total cost, a modified merge sort is utilized. The algorithm creates an auxiliary array and iterates through both arrays, ensuring each part is correctly ordered. Empty spots are prioritized at the beginning if no data exists. Subsequently, the sorted arrays are merged, and the existing droid array is overwritten for final output to the user.

# Images
![screenshot](Images/droidinventorymanager.png)
=======




