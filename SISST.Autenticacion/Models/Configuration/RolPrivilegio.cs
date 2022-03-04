using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace SISST.Autenticacion.Models.Configuration
{

	class RolPrivilegioConfiguration : IEntityTypeConfiguration<RolPrivilegio>
	{
		public void Configure(EntityTypeBuilder<RolPrivilegio> builder)
		{
			builder.ToTable("RolPrivilegio");

			builder.Property(d => d.rolId).IsRequired();
			builder.Property(d => d.privilegioId).IsRequired();

			List<RolPrivilegio> rolPrivilegio = new List<RolPrivilegio>();
			// Administrador
			rolPrivilegio.Add(new RolPrivilegio { id = 1, rolId = 1, privilegioId = 43 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2, rolId = 1, privilegioId = 44 });
			rolPrivilegio.Add(new RolPrivilegio { id = 3, rolId = 1, privilegioId = 42 });
			rolPrivilegio.Add(new RolPrivilegio { id = 4, rolId = 1, privilegioId = 20 });
			rolPrivilegio.Add(new RolPrivilegio { id = 5, rolId = 1, privilegioId = 18 });
			rolPrivilegio.Add(new RolPrivilegio { id = 6, rolId = 1, privilegioId = 17 });
			rolPrivilegio.Add(new RolPrivilegio { id = 7, rolId = 1, privilegioId = 66 });
			rolPrivilegio.Add(new RolPrivilegio { id = 8, rolId = 1, privilegioId = 19 });
			rolPrivilegio.Add(new RolPrivilegio { id = 9, rolId = 1, privilegioId = 16 });
			rolPrivilegio.Add(new RolPrivilegio { id = 10, rolId = 1, privilegioId = 28 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11, rolId = 1, privilegioId = 30 });
			rolPrivilegio.Add(new RolPrivilegio { id = 12, rolId = 1, privilegioId = 27 });
			rolPrivilegio.Add(new RolPrivilegio { id = 13, rolId = 1, privilegioId = 29 });
			rolPrivilegio.Add(new RolPrivilegio { id = 14, rolId = 1, privilegioId = 26 });
			rolPrivilegio.Add(new RolPrivilegio { id = 15, rolId = 1, privilegioId = 6 });
			rolPrivilegio.Add(new RolPrivilegio { id = 16, rolId = 1, privilegioId = 5 });
			rolPrivilegio.Add(new RolPrivilegio { id = 17, rolId = 1, privilegioId = 3 });
			rolPrivilegio.Add(new RolPrivilegio { id = 18, rolId = 1, privilegioId = 4 });
			rolPrivilegio.Add(new RolPrivilegio { id = 19, rolId = 1, privilegioId = 2 });
			rolPrivilegio.Add(new RolPrivilegio { id = 20, rolId = 1, privilegioId = 14 });
			rolPrivilegio.Add(new RolPrivilegio { id = 21, rolId = 1, privilegioId = 15 });
			rolPrivilegio.Add(new RolPrivilegio { id = 22, rolId = 1, privilegioId = 12 });
			rolPrivilegio.Add(new RolPrivilegio { id = 23, rolId = 1, privilegioId = 13 });
			rolPrivilegio.Add(new RolPrivilegio { id = 24, rolId = 1, privilegioId = 11 });
			rolPrivilegio.Add(new RolPrivilegio { id = 25, rolId = 1, privilegioId = 23 });
			rolPrivilegio.Add(new RolPrivilegio { id = 26, rolId = 1, privilegioId = 25 });
			rolPrivilegio.Add(new RolPrivilegio { id = 27, rolId = 1, privilegioId = 22 });
			rolPrivilegio.Add(new RolPrivilegio { id = 28, rolId = 1, privilegioId = 24 });
			rolPrivilegio.Add(new RolPrivilegio { id = 29, rolId = 1, privilegioId = 21 });
			rolPrivilegio.Add(new RolPrivilegio { id = 30, rolId = 1, privilegioId = 10 });
			rolPrivilegio.Add(new RolPrivilegio { id = 31, rolId = 1, privilegioId = 63 });
			rolPrivilegio.Add(new RolPrivilegio { id = 32, rolId = 1, privilegioId = 7 });
			rolPrivilegio.Add(new RolPrivilegio { id = 33, rolId = 1, privilegioId = 64 });
			rolPrivilegio.Add(new RolPrivilegio { id = 34, rolId = 1, privilegioId = 9 });
			rolPrivilegio.Add(new RolPrivilegio { id = 35, rolId = 1, privilegioId = 8 });
			rolPrivilegio.Add(new RolPrivilegio { id = 36, rolId = 1, privilegioId = 1 });
			rolPrivilegio.Add(new RolPrivilegio { id = 37, rolId = 1, privilegioId = 65 });

			rolPrivilegio.Add(new RolPrivilegio { id = 71, rolId = 1, privilegioId = 80 });
			rolPrivilegio.Add(new RolPrivilegio { id = 72, rolId = 1, privilegioId = 81 });
			rolPrivilegio.Add(new RolPrivilegio { id = 73, rolId = 1, privilegioId = 82 });
			rolPrivilegio.Add(new RolPrivilegio { id = 74, rolId = 1, privilegioId = 83 });

			rolPrivilegio.Add(new RolPrivilegio { id = 124, rolId = 1, privilegioId = 62 });
			rolPrivilegio.Add(new RolPrivilegio { id = 125, rolId = 1, privilegioId = 124 });
			rolPrivilegio.Add(new RolPrivilegio { id = 126, rolId = 1, privilegioId = 125 });
			rolPrivilegio.Add(new RolPrivilegio { id = 127, rolId = 1, privilegioId = 126 });
			rolPrivilegio.Add(new RolPrivilegio { id = 128, rolId = 1, privilegioId = 127 });
			rolPrivilegio.Add(new RolPrivilegio { id = 129, rolId = 1, privilegioId = 128 });
			rolPrivilegio.Add(new RolPrivilegio { id = 130, rolId = 1, privilegioId = 129 });
			rolPrivilegio.Add(new RolPrivilegio { id = 131, rolId = 1, privilegioId = 130 });
			rolPrivilegio.Add(new RolPrivilegio { id = 132, rolId = 1, privilegioId = 131 });
			rolPrivilegio.Add(new RolPrivilegio { id = 133, rolId = 1, privilegioId = 132 });
			rolPrivilegio.Add(new RolPrivilegio { id = 134, rolId = 1, privilegioId = 133 });
			rolPrivilegio.Add(new RolPrivilegio { id = 135, rolId = 1, privilegioId = 134 });
			rolPrivilegio.Add(new RolPrivilegio { id = 136, rolId = 1, privilegioId = 135 });
			rolPrivilegio.Add(new RolPrivilegio { id = 137, rolId = 1, privilegioId = 136 });
			rolPrivilegio.Add(new RolPrivilegio { id = 138, rolId = 1, privilegioId = 137 });
			rolPrivilegio.Add(new RolPrivilegio { id = 139, rolId = 1, privilegioId = 138 });
			rolPrivilegio.Add(new RolPrivilegio { id = 140, rolId = 1, privilegioId = 139 });
			rolPrivilegio.Add(new RolPrivilegio { id = 141, rolId = 1, privilegioId = 140 });
			rolPrivilegio.Add(new RolPrivilegio { id = 142, rolId = 1, privilegioId = 141 });
			rolPrivilegio.Add(new RolPrivilegio { id = 143, rolId = 1, privilegioId = 142 });
			rolPrivilegio.Add(new RolPrivilegio { id = 144, rolId = 1, privilegioId = 143 });
			rolPrivilegio.Add(new RolPrivilegio { id = 145, rolId = 1, privilegioId = 144 });
			rolPrivilegio.Add(new RolPrivilegio { id = 146, rolId = 1, privilegioId = 145 });
			rolPrivilegio.Add(new RolPrivilegio { id = 147, rolId = 1, privilegioId = 146 });
			rolPrivilegio.Add(new RolPrivilegio { id = 148, rolId = 1, privilegioId = 147 });
			rolPrivilegio.Add(new RolPrivilegio { id = 149, rolId = 1, privilegioId = 148 });
			rolPrivilegio.Add(new RolPrivilegio { id = 150, rolId = 1, privilegioId = 149 });
			rolPrivilegio.Add(new RolPrivilegio { id = 151, rolId = 1, privilegioId = 150 });
			rolPrivilegio.Add(new RolPrivilegio { id = 152, rolId = 1, privilegioId = 151 });
			rolPrivilegio.Add(new RolPrivilegio { id = 153, rolId = 1, privilegioId = 152 });
			rolPrivilegio.Add(new RolPrivilegio { id = 154, rolId = 1, privilegioId = 153 });
			rolPrivilegio.Add(new RolPrivilegio { id = 155, rolId = 1, privilegioId = 154 });
			rolPrivilegio.Add(new RolPrivilegio { id = 156, rolId = 1, privilegioId = 155 });
			rolPrivilegio.Add(new RolPrivilegio { id = 157, rolId = 1, privilegioId = 156 });
			rolPrivilegio.Add(new RolPrivilegio { id = 158, rolId = 1, privilegioId = 157 });
			rolPrivilegio.Add(new RolPrivilegio { id = 159, rolId = 1, privilegioId = 158 });
			rolPrivilegio.Add(new RolPrivilegio { id = 160, rolId = 1, privilegioId = 159 });
			rolPrivilegio.Add(new RolPrivilegio { id = 161, rolId = 1, privilegioId = 160 });
			rolPrivilegio.Add(new RolPrivilegio { id = 162, rolId = 1, privilegioId = 161 });
			rolPrivilegio.Add(new RolPrivilegio { id = 163, rolId = 1, privilegioId = 162 });
			rolPrivilegio.Add(new RolPrivilegio { id = 164, rolId = 1, privilegioId = 163 });
			rolPrivilegio.Add(new RolPrivilegio { id = 165, rolId = 1, privilegioId = 164 });
			rolPrivilegio.Add(new RolPrivilegio { id = 166, rolId = 1, privilegioId = 165 });
			rolPrivilegio.Add(new RolPrivilegio { id = 167, rolId = 1, privilegioId = 166 });
			rolPrivilegio.Add(new RolPrivilegio { id = 168, rolId = 1, privilegioId = 167 });
			rolPrivilegio.Add(new RolPrivilegio { id = 169, rolId = 1, privilegioId = 168 });
			rolPrivilegio.Add(new RolPrivilegio { id = 170, rolId = 1, privilegioId = 169 });
			rolPrivilegio.Add(new RolPrivilegio { id = 171, rolId = 1, privilegioId = 170 });
			rolPrivilegio.Add(new RolPrivilegio { id = 172, rolId = 1, privilegioId = 171 });

			rolPrivilegio.Add(new RolPrivilegio { id = 173, rolId = 1, privilegioId = 173 });
			rolPrivilegio.Add(new RolPrivilegio { id = 174, rolId = 1, privilegioId = 174 });
			rolPrivilegio.Add(new RolPrivilegio { id = 175, rolId = 1, privilegioId = 175 });
			rolPrivilegio.Add(new RolPrivilegio { id = 176, rolId = 1, privilegioId = 176 });
			rolPrivilegio.Add(new RolPrivilegio { id = 177, rolId = 1, privilegioId = 177 });

			rolPrivilegio.Add(new RolPrivilegio { id = 201, rolId = 1, privilegioId = 201 });
			rolPrivilegio.Add(new RolPrivilegio { id = 202, rolId = 1, privilegioId = 202 });

			rolPrivilegio.Add(new RolPrivilegio { id = 219, rolId = 1, privilegioId = 219 });
			rolPrivilegio.Add(new RolPrivilegio { id = 220, rolId = 1, privilegioId = 211 });

			rolPrivilegio.Add(new RolPrivilegio { id = 240, rolId = 1, privilegioId = 240 });

			rolPrivilegio.Add(new RolPrivilegio { id = 251, rolId = 1, privilegioId = 251 });

			rolPrivilegio.Add(new RolPrivilegio { id = 284, rolId = 1, privilegioId = 284 });
			rolPrivilegio.Add(new RolPrivilegio { id = 285, rolId = 1, privilegioId = 285 });
			rolPrivilegio.Add(new RolPrivilegio { id = 286, rolId = 1, privilegioId = 286 });
			rolPrivilegio.Add(new RolPrivilegio { id = 287, rolId = 1, privilegioId = 287 });
			rolPrivilegio.Add(new RolPrivilegio { id = 288, rolId = 1, privilegioId = 288 });
			rolPrivilegio.Add(new RolPrivilegio { id = 289, rolId = 1, privilegioId = 289 });
			rolPrivilegio.Add(new RolPrivilegio { id = 290, rolId = 1, privilegioId = 290 });
			rolPrivilegio.Add(new RolPrivilegio { id = 291, rolId = 1, privilegioId = 291 });
			rolPrivilegio.Add(new RolPrivilegio { id = 292, rolId = 1, privilegioId = 292 });
			rolPrivilegio.Add(new RolPrivilegio { id = 293, rolId = 1, privilegioId = 293 });

			rolPrivilegio.Add(new RolPrivilegio { id = 370, rolId = 1, privilegioId = 370 });

			rolPrivilegio.Add(new RolPrivilegio { id = 390, rolId = 1, privilegioId = 390 });
			rolPrivilegio.Add(new RolPrivilegio { id = 391, rolId = 1, privilegioId = 391 });
			rolPrivilegio.Add(new RolPrivilegio { id = 392, rolId = 1, privilegioId = 392 });
			rolPrivilegio.Add(new RolPrivilegio { id = 393, rolId = 1, privilegioId = 393 });

			rolPrivilegio.Add(new RolPrivilegio { id = 396, rolId = 1, privilegioId = 396 });
			rolPrivilegio.Add(new RolPrivilegio { id = 397, rolId = 1, privilegioId = 397 });
			rolPrivilegio.Add(new RolPrivilegio { id = 398, rolId = 1, privilegioId = 398 });
			rolPrivilegio.Add(new RolPrivilegio { id = 399, rolId = 1, privilegioId = 399 });
			rolPrivilegio.Add(new RolPrivilegio { id = 400, rolId = 1, privilegioId = 400 });
			rolPrivilegio.Add(new RolPrivilegio { id = 401, rolId = 1, privilegioId = 401 });

			rolPrivilegio.Add(new RolPrivilegio { id = 438, rolId = 1, privilegioId = 438 });
			rolPrivilegio.Add(new RolPrivilegio { id = 439, rolId = 1, privilegioId = 439 });

			rolPrivilegio.Add(new RolPrivilegio { id = 484, rolId = 1, privilegioId = 484 });
			rolPrivilegio.Add(new RolPrivilegio { id = 485, rolId = 1, privilegioId = 485 });
			rolPrivilegio.Add(new RolPrivilegio { id = 486, rolId = 1, privilegioId = 486 });
			rolPrivilegio.Add(new RolPrivilegio { id = 487, rolId = 1, privilegioId = 487 });

			//rolPrivilegio.Add(new RolPrivilegio { id = 10059, rolId = 1, privilegioId = 559 });
			rolPrivilegio.Add(new RolPrivilegio { id = 10096, rolId = 1, privilegioId = 592 });
			rolPrivilegio.Add(new RolPrivilegio { id = 10108, rolId = 1, privilegioId = 604 });

			// Responsable de seguridad Nacional
			rolPrivilegio.Add(new RolPrivilegio { id = 501, rolId = 8, privilegioId = 43 });
			rolPrivilegio.Add(new RolPrivilegio { id = 502, rolId = 8, privilegioId = 44 });
			rolPrivilegio.Add(new RolPrivilegio { id = 503, rolId = 8, privilegioId = 42 });

			rolPrivilegio.Add(new RolPrivilegio { id = 525, rolId = 8, privilegioId = 23 });
			rolPrivilegio.Add(new RolPrivilegio { id = 526, rolId = 8, privilegioId = 25 });
			rolPrivilegio.Add(new RolPrivilegio { id = 527, rolId = 8, privilegioId = 22 });
			rolPrivilegio.Add(new RolPrivilegio { id = 528, rolId = 8, privilegioId = 24 });
			rolPrivilegio.Add(new RolPrivilegio { id = 529, rolId = 8, privilegioId = 21 });
			rolPrivilegio.Add(new RolPrivilegio { id = 530, rolId = 8, privilegioId = 10 });
			rolPrivilegio.Add(new RolPrivilegio { id = 531, rolId = 8, privilegioId = 63 });
			rolPrivilegio.Add(new RolPrivilegio { id = 532, rolId = 8, privilegioId = 7 });
			rolPrivilegio.Add(new RolPrivilegio { id = 533, rolId = 8, privilegioId = 64 });
			rolPrivilegio.Add(new RolPrivilegio { id = 534, rolId = 8, privilegioId = 9 });
			rolPrivilegio.Add(new RolPrivilegio { id = 535, rolId = 8, privilegioId = 8 });
			rolPrivilegio.Add(new RolPrivilegio { id = 536, rolId = 8, privilegioId = 1 });
			rolPrivilegio.Add(new RolPrivilegio { id = 537, rolId = 8, privilegioId = 65 });

			rolPrivilegio.Add(new RolPrivilegio { id = 574, rolId = 8, privilegioId = 83 });
			rolPrivilegio.Add(new RolPrivilegio { id = 740, rolId = 8, privilegioId = 240 });
			rolPrivilegio.Add(new RolPrivilegio { id = 742, rolId = 8, privilegioId = 243 });

			rolPrivilegio.Add(new RolPrivilegio { id = 751, rolId = 8, privilegioId = 251 });

			rolPrivilegio.Add(new RolPrivilegio { id = 755, rolId = 8, privilegioId = 363 });
			rolPrivilegio.Add(new RolPrivilegio { id = 756, rolId = 8, privilegioId = 364 });
			rolPrivilegio.Add(new RolPrivilegio { id = 757, rolId = 8, privilegioId = 365 });
			rolPrivilegio.Add(new RolPrivilegio { id = 758, rolId = 8, privilegioId = 357 });
			rolPrivilegio.Add(new RolPrivilegio { id = 759, rolId = 8, privilegioId = 358 });
			rolPrivilegio.Add(new RolPrivilegio { id = 760, rolId = 8, privilegioId = 359 });

			rolPrivilegio.Add(new RolPrivilegio { id = 869, rolId = 8, privilegioId = 369 });
			rolPrivilegio.Add(new RolPrivilegio { id = 870, rolId = 8, privilegioId = 370 });

			rolPrivilegio.Add(new RolPrivilegio { id = 890, rolId = 8, privilegioId = 390 });
			rolPrivilegio.Add(new RolPrivilegio { id = 891, rolId = 8, privilegioId = 391 });
			rolPrivilegio.Add(new RolPrivilegio { id = 892, rolId = 8, privilegioId = 392 });
			rolPrivilegio.Add(new RolPrivilegio { id = 893, rolId = 8, privilegioId = 393 });
			rolPrivilegio.Add(new RolPrivilegio { id = 895, rolId = 8, privilegioId = 395 });

			rolPrivilegio.Add(new RolPrivilegio { id = 896, rolId = 8, privilegioId = 396 });
			rolPrivilegio.Add(new RolPrivilegio { id = 897, rolId = 8, privilegioId = 397 });
			rolPrivilegio.Add(new RolPrivilegio { id = 898, rolId = 8, privilegioId = 398 });
			rolPrivilegio.Add(new RolPrivilegio { id = 899, rolId = 8, privilegioId = 399 });
			rolPrivilegio.Add(new RolPrivilegio { id = 900, rolId = 8, privilegioId = 400 });
			rolPrivilegio.Add(new RolPrivilegio { id = 901, rolId = 8, privilegioId = 401 });

			rolPrivilegio.Add(new RolPrivilegio { id = 905, rolId = 8, privilegioId = 405 });
			rolPrivilegio.Add(new RolPrivilegio { id = 906, rolId = 8, privilegioId = 406 });
			rolPrivilegio.Add(new RolPrivilegio { id = 907, rolId = 8, privilegioId = 407 });
			rolPrivilegio.Add(new RolPrivilegio { id = 908, rolId = 8, privilegioId = 408 });

			rolPrivilegio.Add(new RolPrivilegio { id = 909, rolId = 8, privilegioId = 409 });
			rolPrivilegio.Add(new RolPrivilegio { id = 910, rolId = 8, privilegioId = 410 });

			rolPrivilegio.Add(new RolPrivilegio { id = 927, rolId = 8, privilegioId = 427 });
			rolPrivilegio.Add(new RolPrivilegio { id = 928, rolId = 8, privilegioId = 428 });
			rolPrivilegio.Add(new RolPrivilegio { id = 929, rolId = 8, privilegioId = 429 });
			rolPrivilegio.Add(new RolPrivilegio { id = 930, rolId = 8, privilegioId = 430 });
			rolPrivilegio.Add(new RolPrivilegio { id = 931, rolId = 8, privilegioId = 431 });

			rolPrivilegio.Add(new RolPrivilegio { id = 933, rolId = 8, privilegioId = 433 });
			rolPrivilegio.Add(new RolPrivilegio { id = 934, rolId = 8, privilegioId = 434 });
			rolPrivilegio.Add(new RolPrivilegio { id = 935, rolId = 8, privilegioId = 435 });
			rolPrivilegio.Add(new RolPrivilegio { id = 936, rolId = 8, privilegioId = 436 });
			rolPrivilegio.Add(new RolPrivilegio { id = 937, rolId = 8, privilegioId = 437 });

			rolPrivilegio.Add(new RolPrivilegio { id = 938, rolId = 8, privilegioId = 438 });
			rolPrivilegio.Add(new RolPrivilegio { id = 939, rolId = 8, privilegioId = 439 });

			rolPrivilegio.Add(new RolPrivilegio { id = 950, rolId = 8, privilegioId = 450 });
			rolPrivilegio.Add(new RolPrivilegio { id = 951, rolId = 8, privilegioId = 451 });
			rolPrivilegio.Add(new RolPrivilegio { id = 952, rolId = 8, privilegioId = 452 });
			rolPrivilegio.Add(new RolPrivilegio { id = 953, rolId = 8, privilegioId = 453 });

			rolPrivilegio.Add(new RolPrivilegio { id = 984, rolId = 8, privilegioId = 484 });
			rolPrivilegio.Add(new RolPrivilegio { id = 985, rolId = 8, privilegioId = 485 });
			rolPrivilegio.Add(new RolPrivilegio { id = 986, rolId = 8, privilegioId = 486 });

			rolPrivilegio.Add(new RolPrivilegio { id = 10559, rolId = 8, privilegioId = 559 });

			rolPrivilegio.Add(new RolPrivilegio { id = 10591, rolId = 8, privilegioId = 587 });
			rolPrivilegio.Add(new RolPrivilegio { id = 10592, rolId = 8, privilegioId = 588 });
			rolPrivilegio.Add(new RolPrivilegio { id = 10593, rolId = 8, privilegioId = 589 });
			rolPrivilegio.Add(new RolPrivilegio { id = 10594, rolId = 8, privilegioId = 590 });
			rolPrivilegio.Add(new RolPrivilegio { id = 10595, rolId = 8, privilegioId = 591 });
			rolPrivilegio.Add(new RolPrivilegio { id = 10596, rolId = 8, privilegioId = 592 });

			// Responsable de seguridad regional
			rolPrivilegio.Add(new RolPrivilegio { id = 1001, rolId = 7, privilegioId = 43 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1002, rolId = 7, privilegioId = 44 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1003, rolId = 7, privilegioId = 42 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1025, rolId = 7, privilegioId = 23 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1026, rolId = 7, privilegioId = 25 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1027, rolId = 7, privilegioId = 22 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1028, rolId = 7, privilegioId = 24 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1029, rolId = 7, privilegioId = 21 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1030, rolId = 7, privilegioId = 10 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1031, rolId = 7, privilegioId = 63 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1032, rolId = 7, privilegioId = 7 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1033, rolId = 7, privilegioId = 64 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1034, rolId = 7, privilegioId = 9 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1035, rolId = 7, privilegioId = 8 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1036, rolId = 7, privilegioId = 1 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1037, rolId = 7, privilegioId = 65 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1038, rolId = 7, privilegioId = 51 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1074, rolId = 7, privilegioId = 83 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1178, rolId = 7, privilegioId = 178 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1179, rolId = 7, privilegioId = 179 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1180, rolId = 7, privilegioId = 180 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1181, rolId = 7, privilegioId = 181 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1206, rolId = 7, privilegioId = 208 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1240, rolId = 7, privilegioId = 240 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1241, rolId = 7, privilegioId = 242 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1251, rolId = 7, privilegioId = 251 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1302, rolId = 7, privilegioId = 302 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1303, rolId = 7, privilegioId = 303 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1304, rolId = 7, privilegioId = 304 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1305, rolId = 7, privilegioId = 305 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1306, rolId = 7, privilegioId = 357 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1307, rolId = 7, privilegioId = 358 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1308, rolId = 7, privilegioId = 359 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1309, rolId = 7, privilegioId = 363 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1310, rolId = 7, privilegioId = 364 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1311, rolId = 7, privilegioId = 365 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1368, rolId = 7, privilegioId = 368 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1370, rolId = 7, privilegioId = 370 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1390, rolId = 7, privilegioId = 390 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1391, rolId = 7, privilegioId = 391 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1392, rolId = 7, privilegioId = 392 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1393, rolId = 7, privilegioId = 393 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1395, rolId = 7, privilegioId = 395 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1396, rolId = 7, privilegioId = 396 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1397, rolId = 7, privilegioId = 397 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1398, rolId = 7, privilegioId = 398 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1399, rolId = 7, privilegioId = 399 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1400, rolId = 7, privilegioId = 400 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1401, rolId = 7, privilegioId = 401 });


			rolPrivilegio.Add(new RolPrivilegio { id = 1409, rolId = 7, privilegioId = 409 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1410, rolId = 7, privilegioId = 410 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1411, rolId = 7, privilegioId = 411 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1427, rolId = 7, privilegioId = 427 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1428, rolId = 7, privilegioId = 428 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1429, rolId = 7, privilegioId = 429 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1430, rolId = 7, privilegioId = 430 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1431, rolId = 7, privilegioId = 431 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1433, rolId = 7, privilegioId = 433 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1434, rolId = 7, privilegioId = 434 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1435, rolId = 7, privilegioId = 435 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1436, rolId = 7, privilegioId = 436 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1437, rolId = 7, privilegioId = 437 });


			rolPrivilegio.Add(new RolPrivilegio { id = 1447, rolId = 7, privilegioId = 447 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1448, rolId = 7, privilegioId = 448 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1449, rolId = 7, privilegioId = 449 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1450, rolId = 7, privilegioId = 450 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1451, rolId = 7, privilegioId = 451 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1452, rolId = 7, privilegioId = 452 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1453, rolId = 7, privilegioId = 453 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1484, rolId = 7, privilegioId = 484 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1485, rolId = 7, privilegioId = 485 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1486, rolId = 7, privilegioId = 486 });

			rolPrivilegio.Add(new RolPrivilegio { id = 11059, rolId = 7, privilegioId = 559 });

			rolPrivilegio.Add(new RolPrivilegio { id = 11091, rolId = 7, privilegioId = 587 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11092, rolId = 7, privilegioId = 588 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11093, rolId = 7, privilegioId = 589 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11094, rolId = 7, privilegioId = 590 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11095, rolId = 7, privilegioId = 591 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11096, rolId = 7, privilegioId = 592 });


			// Responsable de seguridad local
			rolPrivilegio.Add(new RolPrivilegio { id = 1501, rolId = 2, privilegioId = 43 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1502, rolId = 2, privilegioId = 44 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1503, rolId = 2, privilegioId = 42 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1525, rolId = 2, privilegioId = 23 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1526, rolId = 2, privilegioId = 25 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1527, rolId = 2, privilegioId = 22 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1528, rolId = 2, privilegioId = 24 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1529, rolId = 2, privilegioId = 21 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1530, rolId = 2, privilegioId = 10 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1531, rolId = 2, privilegioId = 63 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1532, rolId = 2, privilegioId = 7 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1533, rolId = 2, privilegioId = 64 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1534, rolId = 2, privilegioId = 9 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1535, rolId = 2, privilegioId = 8 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1536, rolId = 2, privilegioId = 1 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1537, rolId = 2, privilegioId = 65 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1538, rolId = 2, privilegioId = 51 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1539, rolId = 2, privilegioId = 55 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1540, rolId = 2, privilegioId = 39 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1541, rolId = 2, privilegioId = 38 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1542, rolId = 2, privilegioId = 36 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1543, rolId = 2, privilegioId = 41 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1544, rolId = 2, privilegioId = 37 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1545, rolId = 2, privilegioId = 40 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1546, rolId = 2, privilegioId = 53 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1547, rolId = 2, privilegioId = 50 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1548, rolId = 2, privilegioId = 52 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1549, rolId = 2, privilegioId = 46 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1551, rolId = 2, privilegioId = 49 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1552, rolId = 2, privilegioId = 35 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1553, rolId = 2, privilegioId = 34 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1554, rolId = 2, privilegioId = 33 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1555, rolId = 2, privilegioId = 54 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1556, rolId = 2, privilegioId = 31 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1557, rolId = 2, privilegioId = 32 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1558, rolId = 2, privilegioId = 67 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1559, rolId = 2, privilegioId = 68 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1560, rolId = 2, privilegioId = 69 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1561, rolId = 2, privilegioId = 70 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1562, rolId = 2, privilegioId = 71 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1563, rolId = 2, privilegioId = 72 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1564, rolId = 2, privilegioId = 73 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1565, rolId = 2, privilegioId = 74 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1566, rolId = 2, privilegioId = 75 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1567, rolId = 2, privilegioId = 76 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1568, rolId = 2, privilegioId = 77 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1569, rolId = 2, privilegioId = 78 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1570, rolId = 2, privilegioId = 79 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1574, rolId = 2, privilegioId = 83 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1575, rolId = 2, privilegioId = 45 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1576, rolId = 2, privilegioId = 47 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1577, rolId = 2, privilegioId = 84 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1578, rolId = 2, privilegioId = 56 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1579, rolId = 2, privilegioId = 61 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1580, rolId = 2, privilegioId = 48 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1581, rolId = 2, privilegioId = 85 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1582, rolId = 2, privilegioId = 86 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1583, rolId = 2, privilegioId = 87 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1584, rolId = 2, privilegioId = 88 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1585, rolId = 2, privilegioId = 57 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1586, rolId = 2, privilegioId = 89 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1587, rolId = 2, privilegioId = 90 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1588, rolId = 2, privilegioId = 91 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1589, rolId = 2, privilegioId = 92 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1590, rolId = 2, privilegioId = 59 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1591, rolId = 2, privilegioId = 93 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1592, rolId = 2, privilegioId = 94 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1593, rolId = 2, privilegioId = 95 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1594, rolId = 2, privilegioId = 96 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1595, rolId = 2, privilegioId = 58 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1596, rolId = 2, privilegioId = 97 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1597, rolId = 2, privilegioId = 98 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1598, rolId = 2, privilegioId = 99 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1599, rolId = 2, privilegioId = 100 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1600, rolId = 2, privilegioId = 60 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1601, rolId = 2, privilegioId = 101 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1602, rolId = 2, privilegioId = 102 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1603, rolId = 2, privilegioId = 103 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1604, rolId = 2, privilegioId = 104 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1605, rolId = 2, privilegioId = 105 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1606, rolId = 2, privilegioId = 106 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1607, rolId = 2, privilegioId = 107 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1608, rolId = 2, privilegioId = 108 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1609, rolId = 2, privilegioId = 109 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1610, rolId = 2, privilegioId = 110 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1611, rolId = 2, privilegioId = 111 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1612, rolId = 2, privilegioId = 112 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1613, rolId = 2, privilegioId = 113 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1614, rolId = 2, privilegioId = 114 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1615, rolId = 2, privilegioId = 115 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1616, rolId = 2, privilegioId = 116 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1617, rolId = 2, privilegioId = 117 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1618, rolId = 2, privilegioId = 118 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1619, rolId = 2, privilegioId = 119 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1620, rolId = 2, privilegioId = 120 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1621, rolId = 2, privilegioId = 121 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1622, rolId = 2, privilegioId = 122 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1623, rolId = 2, privilegioId = 123 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1701, rolId = 2, privilegioId = 201 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1702, rolId = 2, privilegioId = 202 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1706, rolId = 2, privilegioId = 208 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1714, rolId = 2, privilegioId = 214 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1740, rolId = 2, privilegioId = 240 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1741, rolId = 2, privilegioId = 241 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1744, rolId = 2, privilegioId = 244 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1745, rolId = 2, privilegioId = 245 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1746, rolId = 2, privilegioId = 246 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1747, rolId = 2, privilegioId = 247 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1748, rolId = 2, privilegioId = 248 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1749, rolId = 2, privilegioId = 249 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1750, rolId = 2, privilegioId = 250 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1751, rolId = 2, privilegioId = 251 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1752, rolId = 2, privilegioId = 252 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1753, rolId = 2, privilegioId = 253 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1754, rolId = 2, privilegioId = 254 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1755, rolId = 2, privilegioId = 255 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1756, rolId = 2, privilegioId = 256 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1757, rolId = 2, privilegioId = 257 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1758, rolId = 2, privilegioId = 258 });


			rolPrivilegio.Add(new RolPrivilegio { id = 1761, rolId = 2, privilegioId = 261 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1762, rolId = 2, privilegioId = 262 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1763, rolId = 2, privilegioId = 263 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1764, rolId = 2, privilegioId = 264 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1765, rolId = 2, privilegioId = 265 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1766, rolId = 2, privilegioId = 266 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1767, rolId = 2, privilegioId = 267 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1768, rolId = 2, privilegioId = 268 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1769, rolId = 2, privilegioId = 269 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1770, rolId = 2, privilegioId = 270 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1771, rolId = 2, privilegioId = 271 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1772, rolId = 2, privilegioId = 272 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1773, rolId = 2, privilegioId = 273 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1774, rolId = 2, privilegioId = 274 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1775, rolId = 2, privilegioId = 275 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1776, rolId = 2, privilegioId = 276 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1777, rolId = 2, privilegioId = 277 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1778, rolId = 2, privilegioId = 278 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1779, rolId = 2, privilegioId = 279 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1780, rolId = 2, privilegioId = 280 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1781, rolId = 2, privilegioId = 281 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1782, rolId = 2, privilegioId = 282 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1783, rolId = 2, privilegioId = 283 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1794, rolId = 2, privilegioId = 294 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1795, rolId = 2, privilegioId = 295 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1796, rolId = 2, privilegioId = 296 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1797, rolId = 2, privilegioId = 297 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1798, rolId = 2, privilegioId = 298 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1799, rolId = 2, privilegioId = 299 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1800, rolId = 2, privilegioId = 300 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1801, rolId = 2, privilegioId = 301 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1806, rolId = 2, privilegioId = 306 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1807, rolId = 2, privilegioId = 307 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1808, rolId = 2, privilegioId = 308 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1809, rolId = 2, privilegioId = 309 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1810, rolId = 2, privilegioId = 310 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1811, rolId = 2, privilegioId = 311 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1812, rolId = 2, privilegioId = 312 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1813, rolId = 2, privilegioId = 313 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1814, rolId = 2, privilegioId = 314 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1815, rolId = 2, privilegioId = 315 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1816, rolId = 2, privilegioId = 316 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1817, rolId = 2, privilegioId = 317 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1818, rolId = 2, privilegioId = 318 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1819, rolId = 2, privilegioId = 319 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1820, rolId = 2, privilegioId = 320 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1821, rolId = 2, privilegioId = 321 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1822, rolId = 2, privilegioId = 322 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1823, rolId = 2, privilegioId = 323 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1824, rolId = 2, privilegioId = 324 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1825, rolId = 2, privilegioId = 325 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1826, rolId = 2, privilegioId = 326 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1827, rolId = 2, privilegioId = 327 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1828, rolId = 2, privilegioId = 328 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1829, rolId = 2, privilegioId = 329 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1830, rolId = 2, privilegioId = 330 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1831, rolId = 2, privilegioId = 331 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1832, rolId = 2, privilegioId = 332 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1833, rolId = 2, privilegioId = 333 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1834, rolId = 2, privilegioId = 334 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1835, rolId = 2, privilegioId = 335 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1836, rolId = 2, privilegioId = 336 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1837, rolId = 2, privilegioId = 337 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1838, rolId = 2, privilegioId = 338 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1839, rolId = 2, privilegioId = 339 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1840, rolId = 2, privilegioId = 340 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1841, rolId = 2, privilegioId = 341 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1842, rolId = 2, privilegioId = 342 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1843, rolId = 2, privilegioId = 343 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1844, rolId = 2, privilegioId = 344 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1845, rolId = 2, privilegioId = 345 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1846, rolId = 2, privilegioId = 346 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1847, rolId = 2, privilegioId = 347 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1848, rolId = 2, privilegioId = 348 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1849, rolId = 2, privilegioId = 349 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1850, rolId = 2, privilegioId = 350 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1851, rolId = 2, privilegioId = 351 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1852, rolId = 2, privilegioId = 352 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1853, rolId = 2, privilegioId = 353 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1854, rolId = 2, privilegioId = 354 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1858, rolId = 2, privilegioId = 363 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1859, rolId = 2, privilegioId = 364 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1860, rolId = 2, privilegioId = 365 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1870, rolId = 2, privilegioId = 370 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1888, rolId = 2, privilegioId = 388 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1889, rolId = 2, privilegioId = 389 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1890, rolId = 2, privilegioId = 390 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1891, rolId = 2, privilegioId = 391 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1892, rolId = 2, privilegioId = 392 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1893, rolId = 2, privilegioId = 393 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1895, rolId = 2, privilegioId = 395 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1896, rolId = 2, privilegioId = 396 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1897, rolId = 2, privilegioId = 397 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1898, rolId = 2, privilegioId = 398 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1899, rolId = 2, privilegioId = 399 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1900, rolId = 2, privilegioId = 400 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1901, rolId = 2, privilegioId = 401 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1902, rolId = 2, privilegioId = 402 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1903, rolId = 2, privilegioId = 403 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1904, rolId = 2, privilegioId = 404 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1909, rolId = 2, privilegioId = 409 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1910, rolId = 2, privilegioId = 410 });
			
			rolPrivilegio.Add(new RolPrivilegio { id = 1912, rolId = 2, privilegioId = 412 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1916, rolId = 2, privilegioId = 416 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1917, rolId = 2, privilegioId = 417 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1918, rolId = 2, privilegioId = 418 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1919, rolId = 2, privilegioId = 419 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1920, rolId = 2, privilegioId = 420 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1921, rolId = 2, privilegioId = 421 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1922, rolId = 2, privilegioId = 422 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1923, rolId = 2, privilegioId = 423 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1924, rolId = 2, privilegioId = 424 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1925, rolId = 2, privilegioId = 425 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1926, rolId = 2, privilegioId = 426 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1927, rolId = 2, privilegioId = 427 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1928, rolId = 2, privilegioId = 428 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1932, rolId = 2, privilegioId = 432 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1934, rolId = 2, privilegioId = 434 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1935, rolId = 2, privilegioId = 435 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1936, rolId = 2, privilegioId = 436 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1937, rolId = 2, privilegioId = 437 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1940, rolId = 2, privilegioId = 440 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1941, rolId = 2, privilegioId = 441 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1942, rolId = 2, privilegioId = 442 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1943, rolId = 2, privilegioId = 443 });

			rolPrivilegio.Add(new RolPrivilegio { id = 1947, rolId = 2, privilegioId = 447 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1948, rolId = 2, privilegioId = 448 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1949, rolId = 2, privilegioId = 449 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1950, rolId = 2, privilegioId = 450 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1951, rolId = 2, privilegioId = 451 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1952, rolId = 2, privilegioId = 452 });
			rolPrivilegio.Add(new RolPrivilegio { id = 1953, rolId = 2, privilegioId = 453 });


			//rolPrivilegio.Add(new RolPrivilegio { id = 1984, rolId = 2, privilegioId = 484 });
			//rolPrivilegio.Add(new RolPrivilegio { id = 1985, rolId = 2, privilegioId = 485 });
			//rolPrivilegio.Add(new RolPrivilegio { id = 1986, rolId = 2, privilegioId = 486 });

			rolPrivilegio.Add(new RolPrivilegio { id = 11558, rolId = 2, privilegioId = 558 });

			rolPrivilegio.Add(new RolPrivilegio { id = 11560, rolId = 2, privilegioId = 560 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11561, rolId = 2, privilegioId = 561 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11562, rolId = 2, privilegioId = 562 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11563, rolId = 2, privilegioId = 563 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11564, rolId = 2, privilegioId = 564 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11565, rolId = 2, privilegioId = 565 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11566, rolId = 2, privilegioId = 566 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11567, rolId = 2, privilegioId = 567 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11568, rolId = 2, privilegioId = 568 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11569, rolId = 2, privilegioId = 569 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11570, rolId = 2, privilegioId = 570 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11571, rolId = 2, privilegioId = 571 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11572, rolId = 2, privilegioId = 568 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11573, rolId = 2, privilegioId = 569 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11574, rolId = 2, privilegioId = 570 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11575, rolId = 2, privilegioId = 571 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11576, rolId = 2, privilegioId = 572 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11577, rolId = 2, privilegioId = 573 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11578, rolId = 2, privilegioId = 574 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11579, rolId = 2, privilegioId = 575 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11580, rolId = 2, privilegioId = 576 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11581, rolId = 2, privilegioId = 577 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11582, rolId = 2, privilegioId = 578 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11583, rolId = 2, privilegioId = 579 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11584, rolId = 2, privilegioId = 580 });


			rolPrivilegio.Add(new RolPrivilegio { id = 11591, rolId = 2, privilegioId = 587 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11596, rolId = 2, privilegioId = 592 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11599, rolId = 2, privilegioId = 595 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11600, rolId = 2, privilegioId = 596 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11601, rolId = 2, privilegioId = 597 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11602, rolId = 2, privilegioId = 598 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11603, rolId = 2, privilegioId = 599 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11604, rolId = 2, privilegioId = 600 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11605, rolId = 2, privilegioId = 601 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11606, rolId = 2, privilegioId = 602 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11607, rolId = 2, privilegioId = 603 });
			rolPrivilegio.Add(new RolPrivilegio { id = 11608, rolId = 2, privilegioId = 604 });

			// Responsable de proceso o área
			rolPrivilegio.Add(new RolPrivilegio { id = 2001, rolId = 4, privilegioId = 43 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2002, rolId = 4, privilegioId = 44 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2003, rolId = 4, privilegioId = 42 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2031, rolId = 4, privilegioId = 63 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2040, rolId = 4, privilegioId = 39 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2041, rolId = 4, privilegioId = 38 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2042, rolId = 4, privilegioId = 36 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2043, rolId = 4, privilegioId = 41 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2044, rolId = 4, privilegioId = 37 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2045, rolId = 4, privilegioId = 40 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2046, rolId = 4, privilegioId = 53 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2047, rolId = 4, privilegioId = 50 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2048, rolId = 4, privilegioId = 52 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2049, rolId = 4, privilegioId = 46 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2051, rolId = 4, privilegioId = 49 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2052, rolId = 4, privilegioId = 35 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2053, rolId = 4, privilegioId = 34 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2054, rolId = 4, privilegioId = 33 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2055, rolId = 4, privilegioId = 54 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2056, rolId = 4, privilegioId = 31 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2057, rolId = 4, privilegioId = 32 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2058, rolId = 4, privilegioId = 67 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2059, rolId = 4, privilegioId = 68 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2060, rolId = 4, privilegioId = 69 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2061, rolId = 4, privilegioId = 70 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2062, rolId = 4, privilegioId = 71 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2063, rolId = 4, privilegioId = 72 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2064, rolId = 4, privilegioId = 73 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2065, rolId = 4, privilegioId = 74 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2066, rolId = 4, privilegioId = 75 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2067, rolId = 4, privilegioId = 76 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2068, rolId = 4, privilegioId = 77 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2069, rolId = 4, privilegioId = 78 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2070, rolId = 4, privilegioId = 79 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2074, rolId = 4, privilegioId = 83 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2075, rolId = 4, privilegioId = 45 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2085, rolId = 4, privilegioId = 57 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2096, rolId = 4, privilegioId = 97 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2097, rolId = 4, privilegioId = 98 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2098, rolId = 4, privilegioId = 99 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2099, rolId = 4, privilegioId = 100 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2100, rolId = 4, privilegioId = 60 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2101, rolId = 4, privilegioId = 101 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2102, rolId = 4, privilegioId = 102 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2103, rolId = 4, privilegioId = 103 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2104, rolId = 4, privilegioId = 104 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2240, rolId = 4, privilegioId = 240 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2390, rolId = 4, privilegioId = 390 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2391, rolId = 4, privilegioId = 391 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2392, rolId = 4, privilegioId = 392 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2393, rolId = 4, privilegioId = 393 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2396, rolId = 4, privilegioId = 396 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2397, rolId = 4, privilegioId = 397 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2398, rolId = 4, privilegioId = 398 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2399, rolId = 4, privilegioId = 399 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2400, rolId = 4, privilegioId = 400 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2401, rolId = 4, privilegioId = 401 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2409, rolId = 4, privilegioId = 409 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2410, rolId = 4, privilegioId = 410 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2426, rolId = 4, privilegioId = 426 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2427, rolId = 4, privilegioId = 427 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2428, rolId = 4, privilegioId = 428 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2432, rolId = 4, privilegioId = 432 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2434, rolId = 4, privilegioId = 434 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2435, rolId = 4, privilegioId = 435 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2436, rolId = 4, privilegioId = 436 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2437, rolId = 4, privilegioId = 437 });

			// Integrante CSH
			rolPrivilegio.Add(new RolPrivilegio { id = 2540, rolId = 5, privilegioId = 39 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2541, rolId = 5, privilegioId = 38 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2542, rolId = 5, privilegioId = 36 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2543, rolId = 5, privilegioId = 41 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2544, rolId = 5, privilegioId = 37 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2545, rolId = 5, privilegioId = 40 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2546, rolId = 5, privilegioId = 53 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2547, rolId = 5, privilegioId = 50 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2548, rolId = 5, privilegioId = 52 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2549, rolId = 5, privilegioId = 46 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2551, rolId = 5, privilegioId = 49 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2552, rolId = 5, privilegioId = 35 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2553, rolId = 5, privilegioId = 34 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2554, rolId = 5, privilegioId = 33 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2555, rolId = 5, privilegioId = 54 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2556, rolId = 5, privilegioId = 31 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2557, rolId = 5, privilegioId = 32 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2574, rolId = 5, privilegioId = 83 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2601, rolId = 5, privilegioId = 101 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2602, rolId = 5, privilegioId = 102 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2603, rolId = 5, privilegioId = 103 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2604, rolId = 5, privilegioId = 104 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2740, rolId = 5, privilegioId = 240 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2890, rolId = 5, privilegioId = 390 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2891, rolId = 5, privilegioId = 391 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2892, rolId = 5, privilegioId = 392 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2893, rolId = 5, privilegioId = 393 });

			rolPrivilegio.Add(new RolPrivilegio { id = 2896, rolId = 5, privilegioId = 396 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2897, rolId = 5, privilegioId = 397 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2898, rolId = 5, privilegioId = 398 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2899, rolId = 5, privilegioId = 399 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2900, rolId = 5, privilegioId = 400 });
			rolPrivilegio.Add(new RolPrivilegio { id = 2901, rolId = 5, privilegioId = 401 });

			// Aprobador
			rolPrivilegio.Add(new RolPrivilegio { id = 3058, rolId = 6, privilegioId = 67 });
			rolPrivilegio.Add(new RolPrivilegio { id = 3240, rolId = 6, privilegioId = 240 });
			rolPrivilegio.Add(new RolPrivilegio { id = 3390, rolId = 6, privilegioId = 390 });
			rolPrivilegio.Add(new RolPrivilegio { id = 3391, rolId = 6, privilegioId = 391 });
			rolPrivilegio.Add(new RolPrivilegio { id = 3392, rolId = 6, privilegioId = 392 });
			rolPrivilegio.Add(new RolPrivilegio { id = 3393, rolId = 6, privilegioId = 393 });

			rolPrivilegio.Add(new RolPrivilegio { id = 3396, rolId = 6, privilegioId = 396 });
			rolPrivilegio.Add(new RolPrivilegio { id = 3397, rolId = 6, privilegioId = 397 });
			rolPrivilegio.Add(new RolPrivilegio { id = 3398, rolId = 6, privilegioId = 398 });
			rolPrivilegio.Add(new RolPrivilegio { id = 3399, rolId = 6, privilegioId = 399 });
			rolPrivilegio.Add(new RolPrivilegio { id = 3400, rolId = 6, privilegioId = 400 });
			rolPrivilegio.Add(new RolPrivilegio { id = 3401, rolId = 6, privilegioId = 401 });
			// Invitado - Consultor
			rolPrivilegio.Add(new RolPrivilegio { id = 3740, rolId = 3, privilegioId = 240 });


			// Gerente Laboratorio
			rolPrivilegio.Add(new RolPrivilegio { id = 7001, rolId = 10, privilegioId = 471 });
			rolPrivilegio.Add(new RolPrivilegio { id = 7002, rolId = 10, privilegioId = 472 });
			rolPrivilegio.Add(new RolPrivilegio { id = 7003, rolId = 10, privilegioId = 473 });
			rolPrivilegio.Add(new RolPrivilegio { id = 7004, rolId = 10, privilegioId = 474 });
			rolPrivilegio.Add(new RolPrivilegio { id = 7005, rolId = 10, privilegioId = 475 });
			rolPrivilegio.Add(new RolPrivilegio { id = 7006, rolId = 10, privilegioId = 476 });
			rolPrivilegio.Add(new RolPrivilegio { id = 7007, rolId = 10, privilegioId = 477 });


			// Metrologo Laboratorio
			rolPrivilegio.Add(new RolPrivilegio { id = 7301, rolId = 11, privilegioId = 471 });
			rolPrivilegio.Add(new RolPrivilegio { id = 7302, rolId = 11, privilegioId = 474 });
			rolPrivilegio.Add(new RolPrivilegio { id = 7303, rolId = 11, privilegioId = 475 });
			rolPrivilegio.Add(new RolPrivilegio { id = 7304, rolId = 11, privilegioId = 476 });
			rolPrivilegio.Add(new RolPrivilegio { id = 7305, rolId = 11, privilegioId = 477 });

			builder.HasData(rolPrivilegio);

		}
	}
}

