import CountUp from "react-countup";

export const Rate = ({ rate }) => {
  if (!rate) return;

  const val = parseFloat(rate.rate.replace(/,/g, ''));

  return (
    <div className="rate">
      <div className="val">
        <CountUp decimals={4} end={val} duration={2} separator=',' useEasing={true} />
      </div>
      <div className="code">{rate.code}</div>
    </div>
  );
};
