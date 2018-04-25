using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoxExpress;
using InterBox;


namespace InterBox
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IBox());
        }
    }

    //internal class Presentor
    //{
    //    private readonly View _view;
    //    private readonly IBoxi _manager;
    //    private string _currentFilePath;

    //    public Presentor(View view, IBoxi manager)
    //    {
    //        _view = view;
    //        _manager = manager;

    //        _view.ContentChanged += _view_ContentChanged;
    //        _view.FileSaveClick += _view_FileSaveClick;

    //    }

    //    private void _view_FileSaveClick(object sender, EventArgs e)
    //    {
    //        string content = _view.Content;
    //        _manager.SaveContent(content, _currentFilePath);
    //    }

    //    private void _view_ContentChanged(object sender, EventArgs e)
    //    {
    //        string content = _view.Content;
    //    }
    //}
}
