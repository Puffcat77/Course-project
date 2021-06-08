using Course_project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Course_project
{
    /// <summary>
    /// Логика взаимодействия для HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        private List<HelpElement> Helps { get; set; } = new List<HelpElement>();
        private int currentSection;
        private Brush baseButtonBrush;
        public HelpWindow()
        {
            InitializeComponent();
            baseButtonBrush = NextBtn.Background;
            currentSection = 0;

            Helps.Add(new HelpElement() { Section = "Справочники",
                Text = "В данном окне пользователь может выбрать в выпадающем списке " +
                "нужный справочник, который он хочет посмотреть. Также, после выбора справочника, пользователю станет " +
                "доступна кнопка \"Редактировать таблицу\". Если у пользователя будут соответствующие " +
                "права, то таблица войдет в режим редактирования и пользователь сможет изменять записи " +
                "таблицы, при этом рядом с кнопкой загорится красная надпись \"Таблица редактируется\". " +
                "Также, пользователь не сможет сменить справочник, пока не закончит редактирование выбранного " +
                "справочника, повторно нажав на кнопку \"Редактировать таблицу\", при этом также пропадет надпись " +
                "\"Таблица редактируется\". Если пользователь хочет вернуться " +
                "в главное меню, ему надо нажать на кнопку \"В главное меню\"."});
            Helps.Add(new HelpElement()
            {
                Section = "Анализ",
                Text = "В данном окне пользователь может выбрать в выпадающем списке " +
                "различные варианты анализа информации из базы данных, а также " +
                "вернуться в главное меню, нажав на соответствующую кнопку."
            });
            Helps.Add(new HelpElement()
            {
                Section = "Отчеты",
                Text = "В данном окне пользователь может выбрать соответствующий вид отчета, " +
                "нажав на соответствующую кнопку, или вернуться в главное меню. После выбора отчета," +
                "пользователю откроется окно предпросмотра соответствующего отчета. Далее пользователь " +
                "может обновить отчет или же экспортировать отчет нажав на соответствующую кнопку."
            });
            Helps.Add(new HelpElement()
            {
                Section = "Смена пользователя",
                Text = "В данном окне пользователь вводит данные пользователя, чтобы система определила его права." +
                " Пользователь не сможет закрыть это окно, не закрыв приложения. После правильного ввода логина и пароля," +
                "система выводит сообщение о том, под какой категорией пользователя зашел пользователь. После этого, окно закрывается" +
                " и пользователь получает доступ к основному меню."
            });

            ChangeHelpContent(currentSection);
        }

        private void ChangeHelpContent(int sectionNumber) 
        {
            TitleBlock.Text = Helps[currentSection].Section;
            HelpTextBlock.Text = Helps[currentSection].Text;
            if (currentSection == Helps.Count - 1)
                NextBtn.Content = Helps[0].Section;
            else
                NextBtn.Content = Helps[currentSection + 1].Section;
            if (currentSection == 0)
                PrevBtn.Content = Helps[Helps.Count - 1].Section;
            else
                PrevBtn.Content = Helps[currentSection - 1].Section;
        }

        private void PrevBtn_Click(object sender, RoutedEventArgs e)
        {
            currentSection = (currentSection + Helps.Count - 1) % Helps.Count;
            ChangeHelpContent(currentSection);
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            currentSection = (currentSection + 1) % Helps.Count;
            ChangeHelpContent(currentSection);
        }

        private void ToMainMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_MouseMoved(object sender, RoutedEventArgs e)
        {
            var b = (sender as Button);
            b.Background = (b.Background == baseButtonBrush) ? b.Background = Brushes.LawnGreen : b.Background = baseButtonBrush;
        }
    }
}
