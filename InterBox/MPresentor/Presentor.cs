//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using BoxExpress;
//using InterBox;

//namespace Presentor
//{
//    public class Presentor
//    {
//        private readonly View _view;
//        private readonly IBoxi _manager;
//        private string _currentFilePath;

//        public Presentor(View view, IBoxi manager)
//        {
//            _view = view;
//            _manager = manager;

//            _view.ContentChanged += _view_ContentChanged;
//            _view.FileSaveClick += _view_FileSaveClick;

//        }

//        private void _view_FileSaveClick(object sender, EventArgs e)
//        {
//            string content = _view.Content;
//            _manager.SaveContent(content, _currentFilePath);
//        }

//        private void _view_ContentChanged(object sender, EventArgs e)
//        {
//            string content = _view.Content;
//        }
//    }
//}
