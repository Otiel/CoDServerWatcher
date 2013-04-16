using System;
using System.Reflection;
using System.Windows.Forms;

namespace CoDServerWatcher {

    internal static class FormUtil {

        /// <summary>
        /// Returns the opened Form object of type T or null if no Form object of this 
        /// type is opened.
        /// </summary>
        public static T GetOpenedForm<T>() where T: Form {
            foreach (Form openForm in Application.OpenForms) {
                // For each opened form
                if (openForm.GetType() == typeof(T)) {
                    // If the current opened form has the same type than the searched one, found it!
                    return (T) openForm;
                }
            }
            // Return null if the form has not been found
            return null;
        }

        /// <summary>
        /// Initializes a new instance of a Form of type T and opens it. If the form is 
        /// already existing and opened in the application, it just selects it and brings it forward 
        /// to the user. Returns the form opened.
        /// </summary>
        public static T ShowOnce<T>() where T: Form {
            // Get the form if it is already opened
            T form = FormUtil.GetOpenedForm<T>();

            if (form == null) {
                // Form is not already opened

                // Create a new form
                ConstructorInfo ci = typeof(T).GetConstructor(System.Type.EmptyTypes);
                form = (T) ci.Invoke(new Object[0]);
                // Show it
                form.Show();
            } else {
                // Form is already opened

                // Show it
                form.Select();
            }

            return form;
        }
    }
}