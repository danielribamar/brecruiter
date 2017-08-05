FROM microsoft/aspnetcore:1.1
ARG source
WORKDIR .
EXPOSE 80
COPY ${source:-obj/Docker/publish} ${source:-obj/Docker/published} 
ENTRYPOINT ["dotnet", "BRecruiter.Web.Frontend.dll"]
