# Tally WhatsappSender

**Alert : If you already using earlier version then update or replace all the files with new ones (from the repository)**

Send Attachments(Invoices, reports) to Client's Whats-app  without having any API  
using selenium library and chromium driver for perofming automated tasks and controlling the browser

Language used: c#

It is a COM DLL which sends attachments to whats-app by automating the chrome browser using selenium and chrome driver

**Requirements:**

-> Microsoft.net framework version 4 

-> Make sure to place all the files in tally folder - All files should come under Tally Working Directory

-> Dot Net Framework 4.x.x (version 4 or higher)

  You can Download it from here : https://dotnet.microsoft.com/download/dotnet-framework/net40
  
  

**Get Started and Registering DLL**

-> Download all the files and place them in tally folder (working directory)

-> Open CMD in administrator Mode (Elevated mode)

           For 64 Bit
-> Type cd <space> C:\Windows\Microsoft.NET\Framework64\v4.0.30319 ;; change directory

           For 32 Bit
-> Type cd <space> C:\Windows\Microsoft.NET\Framework\v4.0.30319 ;; change directory

          Give Full path of the TallyWhatsappsender.dll file inside double quotes
          
-> Type regasm <space> "fullpathto\TallyWhatsappsender.dll" <space> /codebase

-> you will get success message after it registered

-> Load WhatsappSenderTally.txt in Tally ;;tdl file for sending whats-app


**Working**

-> After Registering and Loading the TDL open or create a sales voucher

-> Ledger(Party) Mobile Number Should be filled and it should be 12 digits including country code(see the image below)

-> On Saving the voucher it will it will ask to send whats-app then it will export the invoice

-> Then Chrome Browser will open Automatically and Navigate to Whats-app site

-> It will wait until you scan the QrCode (Max 60 seconds)

-> Then it send the Attachment/Message to the contact and Close the browser window

**Possible Errors**

-> "contact number is invalid " - this is due you didn't filled the mobile number in ledger and it should be 12 digit including country code (Example - 911234567890)

-> "chrome driver not find " - this is due you didn't place all the files in tally folder or chromedriver.exe file is missing or deleted

-> "attachment not found" - this is due invoice not exported properly after saving, check weather invoice is exported after save or not

-> "Classification not found" - this is due to contact number doesn't have whats-app account check weather party has whats-app account linked to that number or not 

-> "vertical page breaks are too high" - this is tdl error make sure page size is to A4 and orientation is portrait , you can check this by pressing ALT+E in voucher and accept it once

-> "contact not found in whatsapp database" - this is due the contact doesn't have whatsapp account or blocked

**Suggestions**

-> You can extend the functionality by enhancing the tdl and dll code

-> Explore the source code and make improvements as per your needs

 


     For Bug Report and fixes please raise an issue.
