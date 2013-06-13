using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using TopShelfService.Models;

namespace TopShelfService.Controllers
{
     public class ExamsController : ApiController
    {
         Exam[] _exams = new Exam[]
        {
            new Exam{Id = 1, PatientId = "020410-100203-AM", PatientFirstName = "ROBERT", PatientLastName = "HALLER", ExamDate = "02/04/2010", PatientBirthDate = "10/24/1942", NumOfExams = 74, ExamLocation = "4_2_2010_15_52_6_284"},
            new Exam{Id = 2, PatientId = "020410-100203-AM", PatientFirstName = "ROBERT", PatientLastName = "HALLER", ExamDate = "02/04/2010", PatientBirthDate = "10/24/1942",NumOfExams = 33,ExamLocation = "4_2_2010_15_51_37_22"},
            new Exam{Id = 3, PatientId = "020410-011826-PM", PatientFirstName = "LARRY", PatientLastName = "ABBOTT", ExamDate = "02/04/2010", PatientBirthDate = "11/08/1946", NumOfExams = 17 , ExamLocation = "4_2_2010_14_57_17_936"},
            new Exam{Id = 4, PatientId = "020410-105308-AM", PatientFirstName = "MARJORIE", PatientLastName = "BERGMAN", ExamDate = "02/04/2010", PatientBirthDate = "07/26/1926", NumOfExams = 38, ExamLocation = "4_2_2010_14_56_26_171"},
            new Exam{Id = 5, PatientId = "020410-091310-AM", PatientFirstName = "KATHY", PatientLastName = "PHUSTING", ExamDate = "02/04/2010", PatientBirthDate = "11/22/1947", NumOfExams = 63, ExamLocation = "4_2_2010_14_55_22_300"},
            new Exam{Id = 6, PatientId = "020410-013755-PM", PatientFirstName = "COLLEEN", PatientLastName = "MCCLOUD", ExamDate = "02/04/2010", PatientBirthDate = "08/25/1933",NumOfExams = 50, ExamLocation = "4_2_2010_14_54_15_624"},
            new Exam{Id = 7, PatientId = "020310-105335-AM", PatientFirstName = "JOY", PatientLastName = "ADELMAN", ExamDate = "02/03/2010", PatientBirthDate = "12/28/1924", NumOfExams = 53, ExamLocation = "3_2_2010_16_5_37_332"},
            new Exam{Id = 8, PatientId = "020310-125357-PM", PatientFirstName = "ELOISA", PatientLastName = "BAUTISTA", ExamDate = "02/03/2010", PatientBirthDate = "01/13/1958", NumOfExams = 61, ExamLocation = "3_2_2010_16_4_2_786"},
            new Exam{Id = 9, PatientId = "020310-014608-PM", PatientFirstName = "TRUDL", PatientLastName = "BUCHANAN", ExamDate = "02/03/2010", PatientBirthDate = "10/31/1931", NumOfExams = 55, ExamLocation = "3_2_2010_16_2_27_580"},
            new Exam{Id = 10, PatientId = "020310-091937-AM", PatientFirstName = "JOHN", PatientLastName = "SABO", ExamDate = "02/03/2010", PatientBirthDate = "07/17/1922", NumOfExams = 30, ExamLocation = "3_2_2010_16_1_25_600"},
            new Exam{Id = 11, PatientId = "020310-024612-PM", PatientFirstName = "CHARLES", PatientLastName = "SODERSTROM", ExamDate = "02/03/2010", PatientBirthDate = "11/15/1964", NumOfExams = 51, ExamLocation = "3_2_2010_15_59_42_923"},
            new Exam{Id = 12, PatientId = "020310-100733-AM", PatientFirstName = "GEORGE", PatientLastName = "SPEER", ExamDate = "02/03/2010", PatientBirthDate = "03/01/1942", NumOfExams = 53, ExamLocation = "3_2_2010_15_57_59_214"},
            new Exam{Id = 13, PatientId = "020210-023054-PM", PatientFirstName = "KARIMABDUL", PatientLastName = "ZURKHAEV", ExamDate = "02/02/2010", PatientBirthDate = "03/11/1949", NumOfExams = 21, ExamLocation = "2_2_2010_16_7_18_410"},
            new Exam{Id = 14, PatientId = "071", PatientFirstName = "REGINA", PatientLastName = "RALSTON", ExamDate = "02/02/2010", PatientBirthDate = "05/24/1926", NumOfExams = 62, ExamLocation = "2_2_2010_15_31_41_699"},
            new Exam{Id = 15, PatientId = "074", PatientFirstName = "EARL",  PatientLastName = "THIGPEN", ExamDate = "02/02/2010", PatientBirthDate = "12/01/1962", NumOfExams = 85, ExamLocation = "2_2_2010_15_29_31_391"},
            new Exam{Id = 16, PatientId = "020210-091740-AM", PatientFirstName = "VIRGINIA", PatientLastName = "ERWITZ", ExamDate = "02/02/2010", PatientBirthDate = "08/11/1942", NumOfExams = 59, ExamLocation = "2_2_2010_14_20_2_252"},
            new Exam{Id = 17, PatientId = "020210-105817-AM", PatientFirstName = "LEE", PatientLastName = "FULLMER", ExamDate = "02/02/2010", PatientBirthDate = "10/08/1927", NumOfExams = 47, ExamLocation = "2_2_2010_14_18_59_482"},
            new Exam{Id = 18, PatientId = "020210-114316-AM", PatientFirstName = "BOGDAN", PatientLastName = "ZIGICH", ExamDate = "02/02/2010", PatientBirthDate = "09/26/1928", NumOfExams = 44, ExamLocation = "2_2_2010_14_17_55_159"},
            new Exam{Id = 19, PatientId = "070", PatientFirstName = "CHARLES", PatientLastName = "JAMIESON", ExamDate = "02/02/2010", PatientBirthDate = "01/15/1926", NumOfExams = 75, ExamLocation = "2_2_2010_11_19_53_384"},
            new Exam{Id = 20, PatientId = "072", PatientFirstName = "NADIA", PatientLastName = "BAGANI", ExamDate = "02/02/2010", PatientBirthDate = "11/25/1931", NumOfExams = 60, ExamLocation = "2_2_2010_11_18_9_675"},
            new Exam{Id = 21, PatientId = "020110-090246-AM", PatientFirstName = "YEFIM", PatientLastName = "GREMPEL", ExamDate = "02/01/2010", PatientBirthDate = "09/17/1937", NumOfExams = 32, ExamLocation = "1_2_2010_11_11_29_440"},
            new Exam{Id = 22, PatientId = "020110-090246-AM", PatientFirstName = "YEFIM", PatientLastName = "GREMPEL", ExamDate = "02/01/2010", PatientBirthDate = "09/17/1937", NumOfExams = 60, ExamLocation = "1_2_2010_11_10_18_448"}                                        
        };

        public IEnumerable<Exam> Get()
        {
            return _exams;
        }

        public Exam Get(int id)
        {
            var exam = _exams.FirstOrDefault(p => p.Id == id);
            if (exam == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return exam;
        }

        public IEnumerable<Exam> GetExamsByExamDate(string examdate)
        {
            return _exams.Where(p => string.Equals(p.ExamDate, examdate));
        }

        public IEnumerable<Exam> GetExamsByPatientLastName(string lastname)
        {
            return _exams.Where(p => string.Equals(p.PatientLastName, lastname, StringComparison.OrdinalIgnoreCase));
        }

    }
}
