# TallyWhatsappSender
Send Attachments(Invoices, reports) to Client's Whats-app  without having any API  
using selenium library and chromium driver for perofming automated tasks and controlling the browser

language used: c#


it is a COM DLL which send attachments to whats-app by automating the chrome browser

**Requirements:**

1)Microsoft.net framework version 4 

2)Make sure to place all the extracted files in tally folder - All files should come under Tally Working Directory

3).Net Framework 4.x.x

  You can Download from here : https://dotnet.microsoft.com/download/dotnet-framework/net40
  
  

**Get Started and Registering DLL**

1) Download all the files and place them in tally folder (working directory)

2) Open CMD in administrator Mode (Elevated mode)

           For 64 Bit
3) Type cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319 ;; change directory

           For 32 Bit
3) Type cd C:\Windows\Microsoft.NET\Framework\v4.0.30319 ;; change directory


4) Type regasm TallyWhatsappsender.dll /codebase ;;Give Full path of the TallyWhatsappsender.dll file

5) you will get success message after it registered

6) Load WhatsappSenderTally.txt in Tally ;;tdl file for sending whats-app


**Working**

1)After Registering and Loading the TDL open or create a sales voucher

2)Ledger(Party) Mobile Number Should be filled and it should be 12 digits including country code(see the image below)

3) On Saving the voucher it will it will ask to send whats-app then it will export the invoice

4)Then Chrome Browser will open Automatically and Navigate to Whats-app site

5) It will wait until you scan the QrCode

6)Then it send the attachment to the contact and Close the browser window

**Possible Errors**

1) "contact number is invalid " - this is due you didn't filled the mobile number in ledger and it should be 12 digit including country code (Ex 911234567890)

2)"chrome driver not find " - this is due you didn't place all the files in tally folder or chromedriver.exe file is missing or deleted

3)"attachment not found" - this is due invoice not exported properly after saving, check weather invoice is exported after save or not

4)"Classification not found" - this is due to contact number doesn't have whats-app account check weather party has whats-app account linked to that number or not 

5)"vertical page breaks are too high" - this is tdl error make sure page size is to A4 and orientation is portrait , you can check this by pressing ALT+E in voucher and accept it once

5)"contact not found in whatsapp database" - this is due the contact doesn't have whatsapp account or blocked

**Limitations**

1)Currently you can only send to single contact number (multiple contact support will be added in next update)

2)you can only send sales invoices (You can customize the tdl to send whatever the reports you want)

For Bug Report and fixes please raise an issue.
