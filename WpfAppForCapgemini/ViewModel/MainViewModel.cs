using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using WpfApp1.Helpers;


namespace WpfAppForCapgemini
{
    internal class MainViewModel : ObserableObject
    {
        public ObservableCollection<MyImage> Images { set; get; }
        public MainViewModel()
        {
            Images = new ObservableCollection<MyImage>();
        }
        private MyImage selectedImage;

        public MyImage SelectedImage
        {
            get { return selectedImage; }
            set
            {
                if (selectedImage != value)
                {
                    selectedImage = value;
                    OnPropertyChanged(nameof(SelectedImage));
                }
            }
        }


        RelayCommand addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(
                    (obj) =>
                    {
                        var dialog = new CommonOpenFileDialog();
                        dialog.IsFolderPicker = true;
                        CommonFileDialogResult result = dialog.ShowDialog();
                        if (result == CommonFileDialogResult.Ok)
                        {
                            DirectoryInfo info = new DirectoryInfo(dialog.FileName);
                            foreach (var item in info.GetFiles("*.jpg"))
                            {
                                MyImage img = new MyImage();
                                FileInfo fileinfo = new FileInfo(item.FullName);
                                img.FilePath = fileinfo.FullName;
                                img.FileName = fileinfo.Name;
                                Images.Add(img);
                            }
                        }
                    }));
            }

        }
    }
}