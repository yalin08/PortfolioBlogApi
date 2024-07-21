using Autofac;
using AutoMapper;
using Business.AutoMapper;
using Business.Services.Concrete;
using Business.Services.Interface;
using Infrastructure.Repositories.Concrete;
using Infrastructure.Repositories.Interface;

namespace Business.IoC
{
    public class DependencyResolver: Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();

            builder.RegisterType<CommentRepo>().As<ICommentRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CommentService>().As<ICommentService>().InstancePerLifetimeScope();


            builder.RegisterType<CommentRequestRepo>().As<ICommentRequestRepo>().InstancePerLifetimeScope();
            builder.RegisterType<CommentRequestService>().As<ICommentRequestService>().InstancePerLifetimeScope();

            builder.RegisterType<PostRepo>().As<IPostRepo>().InstancePerLifetimeScope();
            builder.RegisterType<PostService>().As<IPostService>().InstancePerLifetimeScope();

            builder.RegisterType<MessageRepo>().As<IMessageRepo>().InstancePerLifetimeScope();
            builder.RegisterType<MessageService>().As<IMessageService>().InstancePerLifetimeScope();





            builder.Register(context => new MapperConfiguration(config =>
            {
                // Register Mapper Profile
                config.AddProfile<Mapping>();
                config.AllowNullCollections = true;
                config.AddGlobalIgnore("Item");
            })).AsSelf().SingleInstance();

            builder.Register(c => {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);

            })
                .As<IMapper>()
                .InstancePerLifetimeScope();


            //Silme.
            base.Load(builder);
        }

    }
}
