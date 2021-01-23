# Tally WhatsappSender

**Check out source code here - https://github.com/tejavarma-aln/TallyWhatsappSender/tree/master/Binary**

Send Attachments(Invoices, reports) to Client's Whats-app  without having any API  

**Added : Support for sending multiple contacts**


**Requirements:**

-> Microsoft.net framework version 4 

-> Make sure to place all the files in tally folder - All files should come under Tally Working Directory

-> Chrome application/binary

-> Dot Net Framework 4.x.x (version 4 or higher)

  You can Download it from here : https://dotnet.microsoft.com/download/dotnet-framework/net40
  
  

**Get Started and Registering DLL**

-> Download and unzip the files from  https://github.com/tejavarma-aln/TallyWhatsappSender/blob/master/Binary/TallyWhatsappsender.zip

-> Place all the files under tally working directory 

-> Open CMD in administrator Mode (Elevated mode)

           For 64 Bit
-> Type cd <space> C:\Windows\Microsoft.NET\Framework64\v4.0.30319 ;; change directory

           For 32 Bit
-> Type cd <space> C:\Windows\Microsoft.NET\Framework\v4.0.30319 ;; change directory

          Give Full path of the TallyWhatsappsender.dll file inside double quotes
          
-> Type regasm <space> "fullpathto\TallyWhatsappsender.dll" <space> /codebase

-> You will get success message after it registered

-> Load WhatsappSenderTally.txt in Tally and start using ;;tdl file for sending whats-app


**Working**

-> After Registering and Loading the TDL open or create a sales voucher

-> Ledger(Party) Mobile Number Should be filled and it should be 12 digits including country code

-> You can put comma seperated value of contact numbers in ledger mobile number for sending to multiple

-> On Saving the voucher it will it will ask to send whats-app then it will export the invoice

-> Then Chrome Browser will open Automatically and Navigate to Whats-app site

-> It will wait until you scan the QrCode (Max 60 seconds)

-> Then it send the Attachment/Message to the contact and Close the browser window

**Possible Errors**

-> "contact number is invalid " - this is due you didn't filled the mobile number in ledger and it should be 12 digit including country code (Example - 911234567890)

-> "chrome driver not find " - this is due you didn't place all the files in tally folder or chromedriver.exe file is missing or deleted

-> "attachment not found" - this is due invoice not exported properly after saving, check weather invoice is exported after save or not


**Support**

-> You can extend the functionality by enhancing the tdl and dll code

-> Explore the source code and make improvements as per your needs


     For Bug Report and fixes please raise an issue.
