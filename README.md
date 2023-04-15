# Unity Optimization Volume Script

This is a C# script for the Unity game engine that optimizes performance by controlling the activation and deactivation of a group of `GameObject` items in a scene based on the player's proximity to the volume.

## Installation

To use this script, follow these steps:

1. Add the `OptimizationVolume` script to a `GameObject` in your scene.
2. Create a trigger `Collider` component on the same `GameObject` and position it where you want the volume to be.
3. Set the `items` array in the `OptimizationVolume` script to contain the `GameObject` items that you want to control.

## Usage

When the player enters the trigger volume of the `OptimizationVolume` object, all the items in the `items` array will be activated. When the player exits the trigger volume, all the items in the `items` array will be deactivated.

## Fields

The script has the following public field:

- `public GameObject[] items`: An array of `GameObject` items that will be controlled by the volume.

## Methods

The script has the following private methods:

- `private void Awake()`: A Unity method called when the script instance is being loaded. It disables the `MeshRenderer` component of the `OptimizationVolume` object to hide it in the scene and sets all the items in the `items` array to inactive by default using the `SetItems` method.

- `private IEnumerator Start()`: A Unity coroutine method called when the script is started. It waits for 2 seconds before enabling the `Collider` component of the `OptimizationVolume` object to prevent clipping issues and sets the `activated` boolean value to true.

- `private void OnTriggerEnter(Collider other)`: A Unity method called when a collider enters the trigger volume of the `OptimizationVolume` object. If the entering collider is tagged as "Player" and the volume is activated, it activates all the items in the `items` array using the `SetItems` method. 

- `private void OnTriggerExit(Collider other)`: A Unity method called when a collider exits the trigger volume of the `OptimizationVolume` object. If the exiting collider is tagged as "Player", it deactivates all the items in the `items` array using the `SetItems` method.

- `private void SetItems(bool active)`: A private method that sets the active state of all the `GameObject` items in the `items` array to the specified `active` state.

## License

This script is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
