Create a local user account
1. Select Start Windows logo Start button > Settings Gear-shaped Settings icon > Accounts Contact icon and then select Family & other users. 
(In some editions of Windows you'll see Other users.) 
2. Select Add someone else to this PC.
3. Select I don't have this person's sign-in information, and on the next page, select Add a user without a Microsoft account.
4. Enter a user name, password, password hint or choose security questions, and then select Next.

-----------------------------------------------------------------------------------------------------------------
Changing the Computer's Name
1. Open Settings and go to System > About.
2. In the About menu, you should see the name of your computer next to PC name and a button that says Rename PC. Click this button.
3. Type the new name for your computer. You can use letters, numbers and hyphens -- no spaces. Then click Next.
4. A window will pop up asking if you want to restart your computer now or later. If you want to change to the new name immediately, 
click Restart now to restart your computer. If you don't want to restart your computer right this second, 
click Restart later. Your computer's name will be updated the next time you restart it.

------------------------------------------------------------------------------------------------------------------
Disabling Task Manager through the Group Policy Editor

The Group Policy is used to manage and configure the working environment of computer accounts and user accounts. 
An administrator can use the Group Policy Editor to enable or disable the Task Manager for standard users. 
The setting will also provide detailed information about the function and purpose of that policy setting.
This setting will disable the Task Manager from all the places on your system.

If you are using the Windows Home version, then skip this method because Group Policy Editor isn’t available in the Windows Home Editions.

1. Hold the Windows key and press R on your keyboard to open a Run dialog. Then type “gpedit.msc” and press the Enter key to open the Group Policy Editor. 
Choose the Yes option when prompted by the UAC (User Account Control).

2. Opening Local Group Policy Editor
3. Navigate to the following path in the Group Policy Editor window:
User Configuration\Administrative Templates\System\Ctrl+Alt+Del Options

4. Navigating to the setting
5. To disable the Task Manager, double-click on the “Remove Task Manager” setting. 
It will open up in a new window, now change the toggle from Not Configured to Enabled and click on Apply/Ok button to save the changes.

6. Enabling the setting
This will disable the Task Manager from Ctrl + Alt + Del screen, shortcuts, and other places.
To enable it back, simply change the toggle option in step 3 back to Not Configured or Disabled.
 The Task Manager will be back to that user account.
 
------------------------------------------------------------------------------------------------------------------
 
Disabling the Control Panel and Settings
All policy settings can be found in the Local Group Policy Editor. Settings in the Local Group Policy Editor are pretty easy to configure anytime. 
This policy setting will remove the control panel from File Explorer and the Start Screen.
 It will also remove the Settings app from the Settings charm, an Account picture, Search results, and the Start screen.

Users that are using Windows Home Edition should skip this method and move to method 2.

If you already got the Local Group Policy Editor on your computer, then follow the below steps to disable access to Control Panel and Settings app:

1. Press the Windows + R keys together to open a Run dialog on your system. Then, type “gpedit.msc” and press the Enter key to open the Local Group Policy Editor.
Note: If UAC (User Account Control) prompt appears, then click on the Yes button.
PRO TIP: If the issue is with your computer or a laptop/notebook you should try using Restoro Repair which can scan the repositories and replace 
corrupt and missing files. This works in most cases, where the issue is originated due to a system corruption. You can download Restoro by Clicking Here

Opening Local Group Policy Editor
2. In the User Configuration of the Local Group Policy Editor, navigate to the following setting:
User Configuration\ Administrative Templates\ Control Panel

Navigating to the policy setting
3. Double-click on the “Prohibit access to Control Panel and PC settings” policy in the list. It will open a new window, 
change the toggle option from Not Configured to Enabled.

4. Disabling access to Control Panel and Settings App
After changing the toggle option, click on Apply then Ok buttons to apply changes. This will disable the Control Panel and Windows Settings app.

---------------------------------------------------------------------------------------------------------------------
Network Configuration
DHCP MUST BE SETTED UP ON THE EXISTING NETWORK OR SPECIAL STATIC ASSIGNMENT MUST BE ASSIGNED FOR THE Server Application

--Restart the PC and sign in the standard User--
