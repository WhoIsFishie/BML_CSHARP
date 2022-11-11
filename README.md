# BML_CSHARP
If you want something done right. you have to do it yourself

# What is this?
this is a c# library im that im making so it would be easier for devs to make apps that communicate with the bml api
the api is made to be fully asyncronus and communicate with the bml api
the code contains easy to undustand method names and comments to make it easy for anyone to pick up and start working with the library 
the code is written in a way any dev can pick it up and forget about the backend and server communication when it comes to the api and start working with the ui straight out of the box

# how to use

before making any api calls to bml servers you have to set baseaddress
this is done due to bml adding bot protection which blocks anyone without a bypass being able to access the api
so enter your own bypass domain here to use the library
```[C#]
 Lib_BML.Statics.BaseURL = "https://bankwebsiteurl/";
 ```

basice usage

```[C#]
private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //try to login and get login result
            Lib_BML.Helpers.ResponseCode.Code result = await Lib_BML.Login.DoLogin(BML_USERNAME, BML_PASSWORD);

            switch (result)
            {
                case Lib_BML.Helpers.ResponseCode.Code.success:
                    await Lib_BML.Profile.GetUserInfoAsync(); //if login true check for user details 
                    
                    ////////////////////////////////////
                    ///do whatever you want from here///
                    ///////////////////////////////////
                    
                    break;
                case Lib_BML.Helpers.ResponseCode.Code.fail:
                    MessageBox.Show("Invalid Login");
                    break;
                case Lib_BML.Helpers.ResponseCode.Code.locked:
                    MessageBox.Show("Account Locked");
                    break;
                case Lib_BML.Helpers.ResponseCode.Code.maintenance:
                    MessageBox.Show("Down for maintenance");
                    break;
                default:
                    break;
            }
        }
```

https://write.mv/fishie-posting/making-my-own-bml-app
