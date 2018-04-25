using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterBox;
using BoxExpress;
using System.Threading.Tasks;

namespace Presentor
{
    public class Presentor
    {
        private readonly IBoxi _manager;
        private readonly View _view;

        private string _currentFilePath;

        public MainPresenter(View view, IBoxi manager)
        {
            _view = view;
            _manager = manager;

            _view.FileOpenClick += _view_FileOpenClick;
            _view.FileSaveClick += _view_FileSaveClick;
        }

        private void _view_FileSaveClick(object sender, EventArgs e)
        {
            try
            {
                string content = _view.Content;
                _manager.SaveContent(content, _currentFilePath);
            }

        }

        private void _view_FileOpenClick(object sender, EventArgs e)
        {
            try
            {
                string filePath = _view.FilePath;
                bool isExist = _manager.IsExist(filePath);
                if (!isExist)
                {
                    _messageService.ShowExclamation("Выбранный файл не существует");
                    return;
                }

                _currentFilePath = filePath;

                string content = _manager.GetContent(filePath);

                _view.Content = content;
            }
            catch(Exception ex)
            {
                _messageService.ShowError(ex.Message);
            }
        }
    }
}
