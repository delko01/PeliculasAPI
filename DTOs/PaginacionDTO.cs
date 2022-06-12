namespace PeliculasApi.DTOs {
    public class PaginacionDTO {
        public int Pagina { get; set; } = 1;
        private int recordsPorPagina = 10;
        private readonly int cantMaxRecordPorPagina = 50;

        public int RecordsPorPagina {
            get { return recordsPorPagina; }
            set { recordsPorPagina = (value > cantMaxRecordPorPagina) ? cantMaxRecordPorPagina : value; }
        }
    }
}
