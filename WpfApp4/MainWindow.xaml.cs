using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfJobCalculator
{
    public partial class MainWindow : Window
    {
        private List<Job> jobs = new List<Job>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddJob_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Введення даних
                int hours = int.Parse(HoursInput.Text);
                int minutes = int.Parse(MinutesInput.Text);
                int hryvnias = int.Parse(HryvniasInput.Text);
                int kopecks = int.Parse(KopecksInput.Text);

                var time = new TTime(hours, minutes);
                var money = new TMoney(hryvnias, kopecks);

                var job = new Job(time, money);
                jobs.Add(job);

                JobsList.Items.Add(job);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CalculateCosts_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder resultBuilder = new StringBuilder();
            decimal totalSum = 0;

            foreach (var job in jobs)
            {
                decimal totalCost = job.CalculateCost();
                totalSum += totalCost;

                // Додаємо до результату інформацію про кожну роботу
                resultBuilder.AppendLine($"{job.Description} -> Вартість: {totalCost:F2} грн");

                // Попередження, якщо витрати перевищують 10 000 грн
                if (totalCost > 10000)
                {
                    MessageBox.Show($"Витрати перевищують 10 000 грн: {job.Description}",
                                    "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            resultBuilder.AppendLine($"Загальна вартість усіх робіт: {totalSum:F2} грн");
            ResultOutput.Text = resultBuilder.ToString();
        }
    }
}
