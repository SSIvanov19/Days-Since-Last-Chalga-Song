const calculateDaysBetwenDates = (date1: Date, date2: Date) => {
  date1.setHours(0, 0, 0, 0);

  if (date2 != undefined)
  {
    date2.setHours(0, 0, 0, 0);
  }
  
  const diff = Math.abs(date1.getTime() - date2?.getTime());
  return Math.floor(diff / (1000 * 3600 * 24));
};

export { calculateDaysBetwenDates };
