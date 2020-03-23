Challanges:
	- learning C# 
		+ properties are neat
	- learning .Net
	- Getting WindowsForm Designer to work with VS2019 :P
	- Designing a WindowsForm
		+ understanding its triggers and trigger handling
		+ Learning about each of the component properties and triggers
	- Designing how we want to calculate data
	- Designing how we want to display data
	- Designing and handling user interaction
	- Speed/optimization
		+ why `eventFire += new SystemEventHandler(MyFunctionPtr);` runs twice compared to just `eventFire += MyFunctionPtr;`?
		+ Mathematical calculations
		+ Formatting and displaying data
			> I think I will go with the image creation version

			-> run program
			-> build window
			-> choose mathematical set
			-> start calculating for default range
			-> display when calculation ready as full window
			->														get user input to change view 
			

			I want the MathematicalSetGenerator to generate an image of size (WxH) (pixles) for the range of (minX,minY) -> (maxX,maxY)
			then I want the manager to request a smaller range for (the same?) WxH for the generator to generate

			If ZoomSpeed = 2    => 512x512 should be scaled to 1024x1024 within S/2      number of seconds
			If ZoomSpeed = 1    => 512x512 should be scaled to 1024x1024 within S        number of seconds
			If ZoomSpeed = 0.5  => 512x512 should be scaled to 1024x1024 within S/0.5    number of seconds
				Next plot points will need to be 512x512 for range (midpoint - distance/4, midpoint + distance/4)

			If ZoomSpeed = 0    => 512x512 should be scaled to 512x512   within infinite number of seconds
			
			If ZoomSpeed = -0.5 => 512x512 should be scaled to 256x256   within S/0.5    number of seconds
			If ZoomSpeed = -1   => 512x512 should be scaled to 256x256   within S		 number of seconds
			If ZoomSpeed = -2   => 512x512 should be scaled to 256x256   within S/2      number of seconds


