// Developer Express Code Central Example:
// Commands in the XtraRichEdit Suite - How to bind commands to buttons, check boxes and other UI elements
// 
// This project illustrates how to bind an XtraRichEdit command to the UI element.
// A DevExpress.XtraEditors.SimpleButton
// (http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsSimpleButtontopic)
// button is bound to Undo command
// (http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraRichEditCommandsUndoCommandtopic)
// via creating a command-enabled descendant. Another SimpleButton is bound to Redo
// command
// (http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraRichEditCommandsRedoCommandtopic)
// via the Command Adapter technique. A CheckEdit
// (http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraEditorsCheckEdittopic)
// is bound to the ToggleFontBold command
// (http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraRichEditCommandsToggleFontBoldCommandtopic).
// Once implemented in the application, the command UI elements properly respond to
// changes in the XtraRichEdit control. This behavior is illustrated by an example,
// in which the command buttons correctly reflect changes in Undo and Redo command
// state. Moreover, all command elements are automatically grayed out and disabled
// when the RichEditControl becomes read-only.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E1774

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("$safeprojectname$")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("-")]
[assembly: AssemblyProduct("$safeprojectname$")]
[assembly: AssemblyCopyright("Copyright © - 2009")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("0ed31ca1-261c-4ded-823d-41ad61753ac0")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
