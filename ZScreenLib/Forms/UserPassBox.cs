﻿#region License Information (GPL v2)

/*
    ZScreen - A program that allows you to upload screenshots in one keystroke.
    Copyright (C) 2008-2011 ZScreen Developers

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v2)

using System;
using System.Windows.Forms;
using DavuxLib.Controls;

namespace ZScreenLib
{
    public partial class UserPassBox : GlassForm
    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public bool Success { get; set; }

        public UserPassBox(string title, string userName, string password)
        {
            InitializeComponent();
            this.Text = title;
            this.txtUserName.Text = userName;
            this.txtPassword.Text = password;
        }

        public UserPassBox(string q, string fullName, string userName, string password)
            : this(q, userName, password)
        {
            this.txtFullName.Text = fullName;
            txtFullName.Enabled = true;
        }

        public UserPassBox(string q, string fullName, string email, string userName, string password)
            : this(q, fullName, userName, password)
        {
            txtEmail.Text = email;
            txtEmail.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                this.UserName = txtUserName.Text;
                this.Password = txtPassword.Text;
                this.Email = txtEmail.Text;
                this.FullName = txtFullName.Text;
                this.DialogResult = DialogResult.OK;
                this.Hide();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
            this.Close();
        }

        private void InputBox_Shown(object sender, EventArgs e)
        {
            txtUserName.Focus();
            txtUserName.SelectionLength = txtUserName.Text.Length;
        }
    }
}