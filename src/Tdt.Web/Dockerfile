# registry.gitlab.com/ekoharita/tdt/v1:develop 
FROM microsoft/aspnetcore-build:2.0 AS build-env 
WORKDIR /app 
# Copy csproj and restore as distinct layers 
COPY *.csproj ./ 
 
RUN dotnet restore 
 
# Copy everything else and build 
COPY . ./ 
RUN dotnet publish -c Release -o out 
 
# Build runtime image 
FROM microsoft/aspnetcore:2.0 
WORKDIR /app 
COPY --from=build-env /app/out . 
 
ENV NODE_VERSION 8.11.1  
ENV NODE_DOWNLOAD_URL https://nodejs.org/dist/v$NODE_VERSION/node-v$NODE_VERSION-linux-x64.tar.gz  
ENV NODE_DOWNLOAD_SHA 0e20787e2eda4cc31336d8327556ebc7417e8ee0a6ba0de96a09b0ec2b841f60    
RUN curl -SL "$NODE_DOWNLOAD_URL" --output nodejs.tar.gz \  
     && echo "$NODE_DOWNLOAD_SHA nodejs.tar.gz" | sha256sum -c - \  
     && tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \  
     && rm nodejs.tar.gz \  
     && ln -s /usr/local/bin/node /usr/local/bin/nodejs  
      
ENV ASPNETCORE_ENVIRONMENT Production 
ENV ASPNETCORE_URLS http://*:5000 
ENTRYPOINT ["dotnet", "Tdt.Web.dll", "--server.urls", "http://*:5000"] 
 
EXPOSE 5000