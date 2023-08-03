.NET MAUI (Multi-platform App UI)
 
How to configure :

1.To use MAUI, it requires Visual Studio 2022 17.3 or greater, or Visual Studio 2022 for Mac 17.4 or greater.

 (a)  Visit this link to install Visual Studio 2022 Community Edition : 
         https://visualstudio.microsoft.com/downloads/  
         https://visualstudio.microsoft.com/vs/community/  
      By following this link  you can also update your already installed Visual Studio. 

 (b)  In case of Enterprise edition, cracked version may face bugs like VS crashing, MAUI controls being disabled or hidden in 
      between  working. VS Enterprise with correct Key will need to be updated to latest version to use MAUI.


2. Once VisualStudioSetup.exe is completed, launch it, we can see two options Installed and Available.
    Installed : currently available Visual Studio versions list will be available. Click on Update then update it to latest version. 
                In case we want to modify currently installed Visual Studio, go to Installed => VS version => Modify.

    Available : You will see VS 2022 Community Edition. Install it. 

   When modifying/Installing Visual Studio, Select VS Studio => Modify => Under Desktop & Mobile Section,
    Select .NET Multi-platform App UI development and Install it. 
  
   Once MAUI installation in VS is done,we can see MAUI project selection in by Searching MAUI in search bar.
   Now we can create a .NET MAUI App or .NET MAUI Blazor App or .NET MAUI Class Library etc.
  
3. This project is based upon .NET MAUI App.
   To install Android Emulator, go to Tools => Android Device Manager

  click on the project execution Button(it may say "Windows Machine") check the drop down, 
  Select Android Emulators => Android Device Manager. 
  Here we can select a Android Device with a android  version of our choice and use it in the emulator.

4.  To run Hyper-v/Hypervisor to accelerate emulator , We can follow one of these steps :
  Option 1 :
            Search in windows : Turn Windows features on or off 
                                Now select check mark on all fields inside
                                - Windows hypervisor platform
                                -Hyper-V
                          
  Option 2 : 
          In some cases, enabling both Hyper-V and Windows Hypervisor Platform in the Turn Windows features on or off dialog,
          may not properly enable Hyper-V. 
          To verify that Hyper-V is  enabled, use the following steps:

          Enter PowerShell in the Windows search box.

          Right-click Windows PowerShell in the search results and select Run as administrator.

          In the PowerShell console, enter the following command:

          Get-WindowsOptionalFeature -FeatureName Microsoft-Hyper-V-All -Online
          If Hyper-V isn't enabled, a message  will be displayed to indicate that the state of Hyper-V is Disabled.
          
          To Enable it,  In the PowerShell console, enter the following command:

          Get-WindowsOptionalFeature -FeatureName HypervisorPlatform -Online
          Now the message  will be displayed to indicate that the state of Hyper-V is Enabled.




Option 3 :
         (a) Right-click on Start then click on Windows PowerShell(admin).

         (b) Copy and paste this command.

         Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Hyper-V -All

         (c) Or you can use the Dism command.

         DISM /Online /Enable-Feature /All /FeatureName:Microsoft-Hyper-V