## Guid Based Reference
License - Please see [LICENSE.md](LICENSE.md) in this repository

### Summary
A component to give a Globaly Unique IDentifier (GUID) to a Game Object. This GUID can then be used to reference an
object even if it is another Scene, not loaded yet, or otherwise not easy to directly reference.

### Maintainers
William Armstrong williama@unity3d.com

### How to use
1. Add a GuidComponent to any object you want to be able to reference.
2. In any code that needs to be able to reference objects by GUID, add a GuidReference field.
3. GuidReference.gameObject will then return the GameObject if it is loaded, otherwise null.

### Sample
Look in the Samples folder for example usage. Load up the LoadFirst scene, and then use the SceneLoader object to load '
LoadSecond'.  
You should see the CrossSceneReferencer object find the CrossSceneTarget object, and set both of them to start spinning.
