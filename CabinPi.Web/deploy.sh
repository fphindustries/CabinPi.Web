dotnet publish /p:PublishProfile=Properties/PublishProfiles/LocalPublish.pubxml
sudo systemctl stop cabinpi-web.service
cp -r  bin/Release/net8.0/linux-arm64/publish/* /opt/cabinpi-web/
sudo systemctl start cabinpi-web.service
sudo systemctl status cabinpi-web.service
