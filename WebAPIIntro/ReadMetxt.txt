Add-Migration İnit
Update-Database


Eğer Migration alınmış fakat sonrasında Update-Database komutu çalıştırılmadıysa o zaman son mşgration db fiziki olarak uygulanmadığından Remove-Migration kodu son migrationı iptal eder. Ve Migration Klasöründeki dosyayı siler

Eğer Migration alınıp sonrasında Update-Database ile dbye aktarıldıysa sadece geri dönüş için tek yol vardır.
Update-Database <MigrationName>
Eğer Migration Klasöründen de silmek istersek aşağıdaki kodu da yazabiliriz.
Remove-Migration



