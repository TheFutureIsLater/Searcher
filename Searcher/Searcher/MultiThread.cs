using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace MultiThread {
    class MultiThread {
        delegate void ControlDelegate(Control _Control, string _Value, object _OptionalMember, object[] _OptionalParameters);
        /// <summary>
        /// Does magic cross thread stuff, I mostly use it for GUI updates from background threads.
        /// </summary>
        /// <param name="_Control">Control that might be on a different Thread</param>
        /// <param name="_Value">Method or Property to set or execute</param>
        /// <param name="_OptionalProperty">Takes NULL or sub-component of _Control that _Value is excecuted on</param>
        /// <param name="_OptionalArg">Takes NULL or object used in setting or executing _Value</param>
        public static void ControlAction(Control _Control, string _Value, object _OptionalMember, object[] _OptionalParameters) {
            if (_Control.InvokeRequired) {
                ControlDelegate d = new ControlDelegate(ControlAction);
                _Control.Invoke(d, new object[] { _Control, _Value, _OptionalMember, _OptionalParameters });
            }
            else {
                try {
                    if (_OptionalMember != null) {//Does stuff with _OptionalProperty instead of _Control
                        if (_Value.Contains('=')) {//Handles setting Properties
                            //Get Property Name
                            PropertyInfo Property = _OptionalMember.GetType().GetProperty(_Value.Split(new char[] { '=' })[0]);

                            //Organize Value
                            object Value;
                            if (_OptionalParameters != null && _OptionalParameters.Length == 1) { Value = _OptionalParameters[0]; }
                            else { Value = _Value.Split(new char[] { '=' })[1]; }

                            //Set Parameter
                            Property.SetValue(_OptionalMember, System.Convert.ChangeType(Value, Property.PropertyType), null);
                        }
                        else {//Handles calling methods
                            //Get Method Name
                            string Method = _Value.Split("( )".ToCharArray())[0];

                            //Organize Parameters
                            object[] parameters;
                            if (_OptionalParameters == null) { parameters = _Value.Split("( )".ToCharArray())[1].Split(", ".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries); }
                            else { parameters = _OptionalParameters; }

                            //Used to specify which method if who have the same name
                            List<Type> Types = new List<Type>();
                            foreach (object O in parameters) { Types.Add(O.GetType()); }

                            //Execute Method
                            _OptionalMember.GetType().GetMethod(Method, Types.ToArray()).Invoke(_OptionalMember, parameters);
                        }
                    }
                    else if (_Value.Contains('=')) {//Handles setting Properties
                        //Get Property
                        PropertyInfo Property = _Control.GetType().GetProperty(_Value.Split(new char[] { '=' })[0]);

                        //Organize Value
                        object Value;
                        if (_OptionalParameters != null && _OptionalParameters.Length == 1) { Value = _OptionalParameters[0]; }
                        else { Value = _Value.Split(new char[] { '=' })[1]; }

                        //Set Property
                        Property.SetValue(_Control, System.Convert.ChangeType(Value, Property.PropertyType), null);
                    }
                    else {//Handles calling methods
                        //Get method name
                        string Method = _Value.Split("( )".ToCharArray())[0];

                        //Organize parameters
                        object[] parameters;
                        if (_OptionalParameters == null) { parameters = _Value.Split("( )".ToCharArray())[1].Split(", ".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries); }
                        else { parameters = _OptionalParameters; }

                        //Used to specify which method if two have the same name.
                        List<Type> Types = new List<Type>();
                        foreach (object O in parameters) { Types.Add(O.GetType()); }

                        //execute method
                        _Control.GetType().GetMethod(Method, Types.ToArray()).Invoke(_Control, parameters);
                    }
                }
                catch (System.Exception x) {
                    if (_OptionalMember == null) {
                        MessageBox.Show(string.Format("Error:{0} ({1}.{2} {3})", x.Message, _Control, _Value, _OptionalParameters[0]), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else {
                        MessageBox.Show(string.Format("Error:{0} ({1}.{2} {3})", x.Message, _OptionalMember, _Value, _OptionalParameters[0]), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        delegate void StatusDelegate(ToolStripStatusLabel _Label, string _Value);
        public static void UpdateToolStripStatus(ToolStripStatusLabel _Label, string _Value) {
            
            if (_Label.GetCurrentParent().InvokeRequired) {
                StatusDelegate d = new StatusDelegate(UpdateToolStripStatus);
                _Label.GetCurrentParent().Invoke(d, new object[] { _Label, _Value });
            }
            else {
                if (_Value.Length > 50)
                {
                    _Value = "..." + _Value.Substring(_Value.Length - 50);
                }
                _Label.Text = _Value;
            }
        }

    }
}
