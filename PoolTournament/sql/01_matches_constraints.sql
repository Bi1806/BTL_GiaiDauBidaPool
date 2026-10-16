-- Chạy từng câu trong Supabase > SQL Editor.
-- Câu nào báo "already exists" thì bỏ qua. Câu nào báo lỗi dữ liệu cũ thì dọn dữ liệu rồi chạy lại.

-- 1. Một cơ thủ chỉ đăng ký một giải một lần
create unique index if not exists uq_participants_tournament_player
  on tournament_participants (tournament_id, player_id);

-- 2. Mỗi giải không có 2 trận trùng (round_name, match_number)
create unique index if not exists uq_matches_round_number
  on matches (tournament_id, round_name, match_number);

-- 3. Một cơ thủ chỉ nằm trong 1 bảng
create unique index if not exists uq_group_players_group_player
  on group_players (group_id, player_id);

-- 4. Giới hạn giá trị trạng thái trận
alter table matches
  add constraint chk_matches_status
  check (status in ('pending','ongoing','completed'));

-- 5. Khóa ngoại (nếu chưa có). Xóa giải sẽ xóa luôn bảng/trận của giải.
alter table groups
  add constraint fk_groups_tournament
  foreign key (tournament_id) references tournaments(id) on delete cascade;

alter table group_players
  add constraint fk_group_players_group
  foreign key (group_id) references groups(id) on delete cascade;

alter table matches
  add constraint fk_matches_tournament
  foreign key (tournament_id) references tournaments(id) on delete cascade;

-- 6. Index cho truy vấn thường dùng
create index if not exists ix_matches_tournament on matches (tournament_id);
create index if not exists ix_groups_tournament on groups (tournament_id);

-- 7. RLS: nếu bảng đã bật Row Level Security mà chưa có policy thì app (dùng publishable key)
--    sẽ KHÔNG đọc/ghi được. Kiểm tra ở Authentication > Policies.
