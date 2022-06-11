API do zarządzania gitarami oraz gitarzystami.
Aplikacja pozwala na zarządzanie gitarami oraz gitarzystami, dodawanie nowych producentów gitar. Każdy gitarzysta posiada listę gitar, którą można modyfikować. Można w ten sposób stworzyć bazę danych gitar oraz gitarzystów korzystających z poszczególnych gitar (kolekcja gitar). Zapytania kierujemy poprzez curl (brak interfejsu (domyślny swagger)).

1. Metody GET:
/api/guitars -> pobiera listę wszystkich gitar
EXAMPLE CURL: 
curl -X 'GET' \
  'https://localhost:7296/api/guitars' \
  -H 'accept: text/plain'

/api/guitars/{id} -> pobiera gitarę o danym ID
EXAMPLE CURL:
/api/guitars/{producer}
EXAMPLE CURL:
curl -X 'GET' \
  'https://localhost:7296/api/guitars/1' \
  -H 'accept: text/plain'

/api/guitars/type/{type} -> pobiera listę gitar o danym typie (string)
EXAMPLE CURL:
curl -X 'GET' \
  'https://localhost:7296/api/guitars/type/electric' \
  -H 'accept: */*'

/api/guitarists -> pobiera listę wszystkich gitarzystów
EXAMPLE CURL:
curl -X 'GET' \
  'https://localhost:7296/api/guitarists' \
  -H 'accept: text/plain'

/api/guitarists/{id} -> pobiera gitarzystę o danym ID
EXAMPLE CURL:
curl -X 'GET' \
  'https://localhost:7296/api/guitarists/1' \
  -H 'accept: text/plain'

/api/guitars/strings -> pobiera listę wszystkich strun
EXAMPLE CURL:
curl -X 'GET' \
  'https://localhost:7296/api/guitars/strings' \
  -H 'accept: text/plain'

/api/guitars/producers -> pobiera listę wszystkich producentów
EXAMPLE CURL:
curl -X 'GET' \
  'https://localhost:7296/api/guitars/producers' \
  -H 'accept: text/plain'

/api/guitars/types -> pobiera listę wszystkich typów gitar
EXAMPLE CURL:
curl -X 'GET' \
  'https://localhost:7296/api/guitars/types' \
  -H 'accept: text/plain'

2. Metody POST:
/api/guitars -> dodaje gitarę
EXAMPLE CURL:
curl -X 'POST' \
  'https://localhost:7296/api/guitars' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "name": "Stratocaster",
  "releaseDate": "1988-06-11T08:22:16.129Z",
  "typeId": 1,
  "stringsId": 3,
  "producerId": 1
}'

/api/guitarists/create -> dodaje gitarzystę
EXAMPLE CURL:
curl -X 'POST' \
  'https://localhost:7296/api/guitarists/create?guitarId=1' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "fullName": "Sting",
  "dateOfBirth": "1966-06-11T08:24:28.575Z"
}'

/api/producers -> dodaje producenta
EXAMPLE CURL:
curl -X 'POST' \
  'https://localhost:7296/api/producers' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "name": "Harmony"
}'

3. Metody DELETE:
/api/guitars/{id} -> usuwa gitarę o danym ID
EXAMPLE CURL:
curl -X 'DELETE' \
  'https://localhost:7296/api/guitars/1' \
  -H 'accept: */*'

/api/guitarists/{id} -> usuwa gitarzystę o danym ID
EXAMPLE CURL:
curl -X 'DELETE' \
  'https://localhost:7296/api/guitarists/1' \
  -H 'accept: */*'

/api/guitarists/deleteguitar -> usuwa gitarę o danym ID (guitarId) od gitarzysty o danym ID (id)
EXAMPLE CURL:
curl -X 'DELETE' \
  'https://localhost:7296/api/guitarists/deleteguitar' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 1,
  "guitarId": 1
}'

4. Metody PUT:
/api/guitars -> update gitary
EXAMPLE CURL:
curl -X 'PUT' \
  'https://localhost:7296/api/guitars' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 1,
  "name": "D-41",
  "releaseDate": "1987-06-11T08:31:09.708Z",
  "typeId": 1,
  "stringsId": 2,
  "producerId": 3
}'

/api/guitarists/addguitar -> dodaje gitarę o danym ID (guitarId) do gitarzysty o danym ID (id)
EXAMPLE CURL:
curl -X 'PUT' \
  'https://localhost:7296/api/guitarists/addguitar' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 2,
  "guitarId": 2
}'