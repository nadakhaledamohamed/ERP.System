



namespace Web.ERP.AutoMapperMaping
{
    public class MappingProfile :Profile
    {
        //maping ben identity role w ben role model 
        public MappingProfile() //constructor 
        {
             CreateMap<IdentityRole, RoleModel>()
            .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.Id))
            .ForMember(dest => dest.RoleName, src => src.MapFrom(src => src.Name))
            .ReverseMap();
            //mmkn a3ks maping f source w destination 

        }
    }
}
