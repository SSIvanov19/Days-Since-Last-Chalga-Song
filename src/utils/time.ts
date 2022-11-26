const calculateDaysBetwenDates = (date1: Date, date2: Date) => {
  const diff = Math.abs(date1.getTime() - date2?.getTime());
  return Math.ceil(diff / (1000 * 3600 * 24));
};

export { calculateDaysBetwenDates };
