#pragma checksum "C:\Users\Usuario\source\repos\Proyecto-UWP\Proyecto blend (UWP)\Proyecto blend (UWP)\Vistas\Registro.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "65ABC2E0E64DBBA7274B78C7B6C5616A5B12335D241BFD413B7766356D5A6406"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_blend__UWP_
{
    partial class Registro : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Vistas\Registro.xaml line 22
                {
                    this.txtNombre = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Vistas\Registro.xaml line 24
                {
                    this.txtEmail = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // Vistas\Registro.xaml line 27
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.goLogInAsync;
                }
                break;
            case 5: // Vistas\Registro.xaml line 28
                {
                    this.btnEntrar = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnEntrar).Click += this.register;
                }
                break;
            case 6: // Vistas\Registro.xaml line 31
                {
                    this.btnFotoPerfil = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnFotoPerfil).Click += this.addProfileImage;
                }
                break;
            case 7: // Vistas\Registro.xaml line 39
                {
                    this.psw = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 8: // Vistas\Registro.xaml line 40
                {
                    this.pswConfirm = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 9: // Vistas\Registro.xaml line 41
                {
                    this.bornDate = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

