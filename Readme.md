# MultiTeamsManager

MultiTeamsManager is a .NET 7 CLI tool that allows you to open multiple instances of Microsoft Teams with different profiles. It provides you with a simple and efficient way to manage multiple Teams profiles.

## Features

- Launch all or selected Teams profiles with ease
- List all profiles
- Add new profiles
- Remove profiles
- Enable/disable profiles
- Rename profiles
- Add MultiTeamsManager to startup for automatic launch at system start
- Remove MultiTeamsManager from startup

## Usage

To use MultiTeamsManager, follow these steps:

1. Open your terminal or command prompt.
2. Navigate to the directory where MultiTeamsManager is located.
3. Type `MultiTeamsManager` followed by a command to perform the desired action.

Here is a list of available commands:

- `launch`: Launch all or selected Teams profiles. Use `-p` or `--profiles` to set the profiles to launch.
- `list`: List all profiles.
- `add <name>`: Add a new profile with the specified name.
- `remove <id>`: Remove the profile with the specified ID.
- `enable <id>`: Enable the profile with the specified ID.
- `disable <id>`: Disable the profile with the specified ID.
- `rename <id> <newname>`: Rename the profile with the specified ID to the new name.
- `startup-add`: Add MultiTeamsManager to startup for automatic launch at system start.
- `startup-remove`: Remove MultiTeamsManager from startup.

It is recommended to place MultiTeamsManager under \<main drive>\\_MultiTeamsManager.

## Examples

Here are some examples of how to use MultiTeamsManager:

- To launch all profiles, type `MultiTeamsManager launch`.
- To launch selected profiles, type `MultiTeamsManager launch -p 1 -p 2` (where 1 and 2 are the IDs of the profiles to be launched).
- To list all profiles, type `MultiTeamsManager list`.
- To add a new profile, type `MultiTeamsManager add profile2` (where profile2 is the name of the profile to be added).
- To remove a profile, type `MultiTeamsManager remove 2` (where 2 is the ID of the profile to be removed).
- To enable a profile, type `MultiTeamsManager enable 1` (where 1 is the ID of the profile to be enabled).
- To disable a profile, type `MultiTeamsManager disable 1` (where 1 is the ID of the profile to be disabled).
- To rename a profile, type `MultiTeamsManager rename 2 newprofile` (where 2 is the ID of the profile to be renamed, and `newprofile` is the new name).
- To add MultiTeamsManager to startup, type `MultiTeamsManager startup-add`.
- To remove MultiTeamsManager from startup, type `MultiTeamsManager startup-remove`.

## Conclusion

MultiTeamsManager is a fantastic tool for those who need to use Microsoft Teams for multiple customers, projects, or teams. Microsoft does not allow users to open multiple instances of Teams with different profiles, but MultiTeamsManager solves this problem. With MultiTeamsManager, you can easily switch between different Teams profiles, allowing you to manage multiple communication channels and Teams tenants with ease. This is particularly useful for business cases where you need to communicate with multiple customers or teams and want to keep their information separate. With MultiTeamsManager, you can now manage all your Teams profiles efficiently and effectively, saving you time and making your work easier. So, if you want to take


## License

Copyright (c) 2023 Alexander Zabel

MultiTeamsManager is provided as-is under the MIT license. For more information see LICENSE.

* SixLabors.ImageSharp, a library which Spectre.Console (which is used by MultiTeamsManager) relies upon, is licensed under Apache 2.0 when distributed as part of Spectre.Console and which is used by MultiTeamsManager. The Six Labors Split License covers all other usage, see: https://github.com/SixLabors/ImageSharp/blob/master/LICENSE 