🤝 BombRush - Collaboration Rules

📁 Project Repo: BombRush_SGJproject🧑‍💻 Tim Development: [seccastudio] + collaborators

📂 Branching Rules

main: branch rilis (stabil, hanya dari hasil merge develop)

develop: branch pengembangan utama

feature/nama-fitur: fitur baru (misal: feature/enemy-ai)

hotfix/nama-bug: perbaikan bug yang urgent (misal: hotfix/nullref-inventory)

prototype/nama: untuk eksperimen ide sebelum dimasukkan ke develop

💼 Commit Rules

Gunakan format commit berikut:

[tipe] Nama fitur secara singkat

Contoh:

[feat] Tambah sistem lempar log

[fix] Perbaikan posisi deteksi monster

[ui] Update tampilan UI inventory

[refactor] Pisahkan logic crafting dari UI

Tip: Gunakan bahasa Indonesia karena tim kita lokal.

🔄 Pull Request (PR)

Semua perubahan ke main atau develop harus lewat PR

Tambahkan deskripsi yang jelas: apa yang diubah, kenapa

Assign reviewer jika perlu diskusi

🧠 Folder Struktur (wajib dipatuhi)

Contoh struktur di folder Unity:

Assets/
│
├── _ProjectCore         ← logic utama: manager, sistem game
├── _UI                  ← canvas, prefab UI, script UI
├── _Scenes              ← semua scene (*.unity)
├── _Art                 ← asset visual, sprite, shader
├── _Audio               ← SFX, BGM
├── _Scripts             ← logic modular tambahan
├── _Testing             ← fitur eksperimen

❌ Yang Tidak Boleh Di-commit

Pastikan file berikut tidak di-track:

Library/, Temp/, Logs/, UserSettings/

File build (.exe, .apk, dll)

Hasil cache atau .DS_Store

Gunakan .gitignore yang sesuai!

⏱️ Sync Rutin

Lakukan git pull origin develop sebelum mulai kerja

Push setelah perubahan selesai dan tidak mengganggu yang lain

Kalau konflik, selesaikan dengan bijak dan diskusi terbuka

🗣️ Komunikasi

Pakai Discord/WhatsApp untuk diskusi cepat

Tulis dokumentasi kecil untuk fitur baru (bisa di Notion/GDoc)

Jangan ragu tanya kalau bingung

