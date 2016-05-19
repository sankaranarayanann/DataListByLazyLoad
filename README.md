# DataListByLazyLoad

1. MainActivity has the MainViewModel which initialize the Json data from the web url.
2. UI control will the initialized and with the json data DataListAdapter will be created.
3. Component Picasso has been used for Image Lazy load and Image cache.
4. Picasso loads the image asynchronously, so that the UI will not get hold for this.
5. LazyLoadDataList.Data is a Portable Android library project carries all the data for the App.
6. LazyLoadDataList.Data project takes care of the Model and ViewModel
7. LazyLoadDataList.Service is a Portable Android library project carries all the servie calls for the App.
8. AppConstant Class holds the const values for the App.
9. Refresh button will gets the latest json data and loads to the Listview
10. Tested the debug version in Moto E(4.4.4) and Nexus 5(6.0.1)
