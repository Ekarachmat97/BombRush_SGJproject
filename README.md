# BombRush Collaboration Rules

Project repository: `BombRush_SGJproject`  
Tim development: seccastudio & contributors

---

## 1. Branching Strategy

Gunakan sistem branching berikut:

- `main`: Branch produksi (rilis stabil)
- `develop`: Branch utama untuk pengembangan
- `feature/nama-fitur`: Untuk pengembangan fitur baru  
  Contoh: `feature/inventory-system`
- `hotfix/nama-bug`: Untuk perbaikan bug kritis  
  Contoh: `hotfix/fix-npe`
- `prototype/nama`: Untuk eksperimen atau fitur uji coba

---

## 2. Commit Guidelines

Format commit:

[tags] Penjelasan singkat fitur

Tags yang direkomendasikan:

- `feat`: Fitur baru
- `fix`: Perbaikan bug
- `ui`: Perubahan tampilan antarmuka
- `refactor`: Perubahan struktur kode tanpa mengubah fungsi
- `docs`: Dokumentasi
- `test`: Penambahan atau perbaikan testing

Contoh:

[feat] Tambahkan sistem crafting
[fix] Perbaiki bug pada deteksi monster

Gunakan bahasa Indonesia yang singkat dan jelas.

---

## 3. Pull Request (PR) Workflow

- Semua perubahan ke `main` dan `develop` harus melalui PR.
- Deskripsikan isi PR secara ringkas dan jelas.
- Sertakan alasan perubahan jika perlu.
- Jangan langsung merge jika PR berisiko konflik — lakukan diskusi dulu.

---

## 4. Struktur Folder Unity

Gunakan struktur berikut:

_Game/

├── Script/ // Script utama: manager, kontrol sistem

├── Prefabs/ // Prefab dan script UI

├── Scenes/ // Semua scene game (*.unity)

├── Art/ // Sprite, shader, animasi,audio


---

## 5. Git Ignore Rules

Pastikan file berikut **tidak masuk Git**:

- `Library/`, `Temp/`, `Logs/`, `UserSettings/`
- Semua file build (*.exe, *.apk)
- File editor lokal (`.vscode`, `.DS_Store`)
- Auto-generated file Unity: `*.csproj`, `*.sln`

Gunakan file `.gitignore` Unity standar.

---

## 6. Sync & Collaboration Routine

- Selalu `git pull origin develop` sebelum mulai kerja.
- `git push` hanya jika perubahan sudah aman dan stabil.
- Resolve konflik dengan hati-hati dan diskusikan jika perlu.
- Gunakan branch per fitur agar kolaborasi tetap modular.

---

## 7. Dokumentasi & Komunikasi

- Dokumentasikan fitur atau sistem baru (Notion/GDocs).
- Gunakan Discord/WA untuk komunikasi real-time.
- Transparansi dan kejelasan adalah prioritas dalam tim.

---

**Catatan:** Jika ada peraturan baru atau revisi, harap update file ini secara kolektif melalui PR.
