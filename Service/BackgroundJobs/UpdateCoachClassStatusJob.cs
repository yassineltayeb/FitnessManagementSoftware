using Quartz;
using Repository.Enum;
using Repository.Interface;

namespace Service.BackgroundJobs
{
    public class UpdateCoachClassStatusJob : IJob
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCoachClassStatusJob(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            // Get In Process Coach Classes
            var coachClasses = await _unitOfWork.CoachClasses.GetCoachClassesInProcess();

            if (coachClasses == null)
                return;

            var onProgressClasses = new List<long>();
            var finishedClasses = new List<long>();

            foreach(var coachClass in coachClasses)
            {
                if((coachClass.ClassFrom <= DateTime.UtcNow) && (coachClass.ClassTo > DateTime.UtcNow))
                {
                    onProgressClasses.Add(coachClass.Id);
                }

                if (coachClass.ClassTo < DateTime.UtcNow)
                {
                    finishedClasses.Add(coachClass.Id);
                }

            }

            if(onProgressClasses.Count() > 0)
            {
                _unitOfWork.CoachClasses.CoachClassesBulkUpdateStatus(onProgressClasses, (int)CoachClassStatusEnum.OnProgress);
            }

            if (finishedClasses.Count() > 0)
            {
                _unitOfWork.CoachClasses.CoachClassesBulkUpdateStatus(finishedClasses, (int)CoachClassStatusEnum.Finished);
            }
        }
    }
}
