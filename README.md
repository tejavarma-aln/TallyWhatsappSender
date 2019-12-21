# TallyWhatsappSender
Send Attachments(Invoices, reports) to Client's Whats-app  without having any API  
using selenium library and chromium driver for perofming automated tasks and controlling the browser

language used: c#


it is a COM DLL which send attachments to whats-app by controlling the chrome browser

Requirements:

1)You Must have latest Version of Google Chrome browser installed on your system or update existing one
2)Required Chrome Version :79.x.x.xx
you can check the version of chrome by open chrome ->go-to settings->help->click on about chrome (see the image below)
3)Microsoft.net framework version 4 
4)Make sure to place all the extracted files in tally folder

Registering DLL:

1) Download the file TallyWhatsappSender.rar attached below
2)Extract all the files into Tally folder 
3)Open CMD in administrator Mode (Elevated mode)
4) Type cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319 ;; change directory
5)Type without quote "regasm TallyWhatsappsender.dll /codebase" ;;Give Full path of the TallyWhatsappsender.dll file
6)you will get success message after it registered
7) Load WhatsappSenderTally.txt in Tally ;;tdl file for sending whats-app


Working:
1)After Registering and Loading the TDL open or create a sales voucher
2)Ledger(Party) Mobile Number Should be filled and it should be 12 digits including country code(see the image below)
3) On Saving the voucher it will it will ask to send whats-app then it will export the invoice
4)Then Chrome Browser will open Automatically and Navigate to Whats-app sit
5) It will wait until you scan the QrCode
6)Then it send the attachment to the contact and Close

Errors:
1) "contact number is invalid " - this is due you didn't filled the mobile number in ledger and it should be 12 digit including country code (Ex 911234567890)
2)"chrome driver not find " - this is due you didn't place all the files in tally folder or chromedriver.exe file is missing or deleted
3)"attachment not found" - this is due invoice not exported properly after saving, check weather invoice is exported after save or not
4)"Classification not found" - this is due to contact number doesn't have whats-app account check weather party has whats-app account linked to that number or not 
5)"vertical page breaks are too high" - this is tdl error make sure page size is to A4 and orientation is portrait , you can check this by pressing ALT+E in voucher and accept it once

Limitations:

1)Currently you can only send to single contact number (multiple contact support will be added in next update)
2)you can only send sales invoices (You can customize the tdl to send whatever the reports you want)
