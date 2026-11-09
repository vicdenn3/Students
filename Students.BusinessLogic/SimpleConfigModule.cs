using Ninject.Modules;
using Students.DataAccessLayer;
using Students.Model;

namespace Students.BusinessLogic
{
    /// <summary>
    /// Модуль Ninject — таблица соответствий «интерфейс -> реализация», которую читает контейнер.
    /// </summary>
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            // Основная (по умолчанию) реализация репозитория — EF Core.
            // InSingletonScope() => Ninject создаёт ОДИН экземпляр на всё приложение.
            Bind<IRepository<Student>>()
                .To<EFRepository>()
                .InSingletonScope();

            // Вторая реализация того же интерфейса (для переключения провайдера).
            // Привязываем по конкретному классу, чтобы не было конфликта с безымянной
            // привязкой выше: Ninject выбрал бы «более одного кандидата».
            Bind<DapperRepository>()
                .ToSelf()
                .InSingletonScope();
        }
    }
}
