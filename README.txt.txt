README.txt 

Setup:
1) Building the .NET 6.0 solution from the src code and running should launch the api on localhost:7016 . A browser window should be launched (swagger) where the api should be visible. Whilst the api can be called from this browser page, I recommend calling it via the React Project frontend.
2) Using npm run start in a terminal at the root folder level of the infotrackui should launch the front end. There should be two inputs and a title and a button for submission of the form.
3) Filling out the form and submitting should then engage the backend api to make the web scraping request.

Comments:
1) Attempted the project using .NET 6 alongside ReactJS front end. 
2) A SOCS cookie token needed to be added, as the "accept/reject" cookies pop up would prevent successful webscraping responses.
3) The UI side uses reusable components in the spirit of React. It also contains some tests. You can run these tests from a terminal using npm run test. The UI side also makes use of tailwindcss for in-line styling.
4) A consideration was made on whether to use a database for logging or whether to simply output to a text file. As the API was fairly lean, it was decided to simply output to a text file, located at .\InfoTrackWebScrape\bin\Debug\net6.0. If necessary, I would be happy to add a database connection and string and configure this.
5) Due to consideration of the recommended timing in the project briefing, there are likely many areas of oversight. Ideally with more time I would have liked to make a more resilient project with more appealing UI. I would have liked to add further functionality and tests.
6) Due to Google search's response of search results having ads, images , etc in recent years, the number of search result links returned may not be exactly 100 (sometimes returning 105-110 results) despite the {num} parameter being set to 100.   