<template>
  <bar-chart
    :chart-data="visibleChartData"
  />
</template>

<script>
import { Chart, registerables } from 'chart.js'
import { BarChart } from 'vue-chart-3'

Chart.register(...registerables)

export default {
  name: 'Chart',
  components: { BarChart },
  props: {
    chartData: {
      type: Array,
      require: true
    }
  },
  computed: {
    visibleChartData () {
      return {
        labels: [...this.chartData.map(data => data.label)],
        datasets: [
          {
            label: 'Продажи',
            data: [...this.chartData.map(data => data.value)],
            backgroundColor: '#5558DAFF'
          }
        ]
      }
    }
  }
}
</script>
