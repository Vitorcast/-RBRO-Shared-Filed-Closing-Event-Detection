# RBRO - Windows Shared File Closing Event Detection

This project is a prototype implementation demonstrating how to use WINDOWS embedded feature called OPENFILES to detect if a shared file
or folder is closed

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

### Prerequisites

Visual Studio 2017 running as Administrator

## Running the demo

Make sure that the project is built to x64 on project properties page

Run (F5)

## OPENFILES Commands Arguments

OPENFILES /parameter [arguments]

Description:
Enables an administrator to list or disconnect files and folders that have been opened on a system.

Parameter List:  
/Disconnect     Disconnects one or more open files.  
/Query            Displays files opened locally or from shared folders.  
/Local             Enables / Disables the display of local open files.  
/?                    Displays this help message.  

OPENFILES /DISCONNECT  

OPENFILES /Disconnect [/S system [/U username [/P [password]]]]  
{[/ID id] [/A accessedby] [/O openmode]}  
[/OP openfile]  

Description:
Enables an administrator to disconnect files and folders that have been opened remotely through a shared folder.

Parameter List:  
/S     system             Specifies the remote system to connect to.  
/U [domain\]user      Specifies the user context under which the command should execute.  
/P [password]          Specifies the password for the given user context.  
/ID     id                    Specifies to disconnect open files by file ID. The "\*" wildcard may be used.  
/A      accessedby     Specifies to disconnect all open files by "accessedby" value. The "*" wildcard may be used.  
/O     openmode       Specifies to disconnect all open files by "openmode" value. Valid values are Read, Write or Read/Write. The "\*" wildcard may be used.  
/OP     openfile          Specifies to disconnect all open file connections created by a specific "open file" name. The "\*" wildcard may be used.  
/?                              Displays this help message.  
OPENFILES / QUERY  
OPENFILES /Query [/S system [/U username [/P [password]]]]  
[/FO format] [/NH] [/V]

Description:
Enables an administrator to display a list of files and folders that have been remotely opened on a system.

Parameter List:
/S     system         Specifies the remote system to connect to.  
/U [domain\]user  Specifies the user context under which the command should execute.  
/P [password]      Specifies the password for the given user context.  
/FO format           Specifies the format in which the output is to be displayed. Valid values: "TABLE","LIST","CSV".  
/NH                     Specifies that the "Column Header" should not be displayed. Valid only for "TABLE" and "CSV" formats.  
/V                        Specifies that verbose output is displayed  
/?                         Displays this help message.  

OPENFILES /LOCAL

OPENFILES /Local [ ON | OFF ]

Description:
Allows an administrator to enable or disable the system global flag 'maintain objects list' which tracks local file handles. Changes made by this switch will take effect only after restarting the system.


Note: Enabling this flag reduces system performance.

Parameter List:
/? Displays this help message.

### Examples

OPENFILES /Disconnect /?  
OPENFILES /Disconnect /ID 1  
OPENFILES /Disconnect /A username  
OPENFILES /Disconnect /O Read/Write  
OPENFILES /Disconnect /OP "c:\My Documents\somedoc.doc" /ID 234  
OPENFILES /Disconnect /S system /U username /ID 5  
OPENFILES /Disconnect /S system /U username /P password /ID *  


OPENFILES /Query /?  
OPENFILES /Query  
OPENFILES /Query /FO csv /NH  
OPENFILES /Query /FO LIST /V 
OPENFILES /Query /S system /U username /P password /NH  


OPENFILES /Local /?   
OPENFILES /Local  
OPENFILES /Local ON  
OPENFILES /Local OFF  

## Findstr Command Arguments

findstr [/b] [/e] [/l | /r] [/s] [/i] [/x] [/v] [/n] [/m] [/o] [/p] [/f:<File>] [/c:<String>] [/g:<File>] [/d:<DirList>] [/a:<ColorAttribute>] [/off[line]] <Strings> [<Drive>:][<Path>]<FileName>[ ...]

### Parameters

Parameter	Description
/b	Matches the text pattern if it is at the beginning of a line.  
/e	Matches the text pattern if it is at the end of a line.  
/l	Processes search strings literally. 
/r	Processes search strings as regular expressions. This is the default setting.  
/s	Searches the current directory and all subdirectories.  
/i	Ignores the case of the characters when searching for the string.  
/x	Prints lines that match exactly.  
/v	Prints only lines that do not contain a match.  
/n	Prints the line number of each line that matches.  
/m	Prints only the file name if a file contains a match.  
/o	Prints character offset before each matching line.  
/p	Skips files with non-printable characters.  
/off[line]	Does not skip files that have the offline attribute set.  
/f:<File>	Gets a file list from the specified file.  
/c:<String>	Uses the specified text as a literal search string.  
/g:<File>	Gets search strings from the specified file.  
/d:<DirList>	Searches the specified list of directories. Each directory must be separated with a semicolon (;), for example dir1;dir2;dir3.  
/a:<ColorAttribute>	Specifies color attributes with two hexadecimal digits. Type color /? for additional information.  
<Strings>	Specifies the text to search for in FileName. Required.  
[<Drive>:][][ ...]	Specifies the location and file or files to search. At least one file name is required.  
/?	Displays Help at the command prompt.  


All findstr command-line options must precede Strings and FileName in the command string.
Regular expressions use both literal characters and metacharacters to find patterns of text, rather than exact strings of characters. A literal character is a character that does not have a special meaning in the regular-expression syntax—it matches an occurrence of that character. For example, letters and numbers are literal characters. A metacharacter is a symbol with special meaning (an operator or delimiter) in the regular-expression syntax.

The following table lists the metacharacters that findstr accepts.

Metacharacter	Value
.	Wildcard: any character
*	Repeat: zero or more occurrences of the previous character or class
^	Line position: beginning of the line
$	Line position: end of the line
[class]	Character class: any one character in a set
[^class]	Inverse class: any one character not in a set
[x-y]	Range: any characters within the specified range
\x	Escape: literal use of a metacharacter x
\<string	Word position: beginning of the word
string>	Word position: end of the word

## Built With

* [OPENFFILE](http://dosprompt.info/commands/openfiles.asp) - OpenFile Documentation Page
* [FINDSTR](https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/findstr ) - Findstr Documentation Page


## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Thiago Castilho** - [Vitorcast](https://github.com/Vitorcatst)

