<template>
  <showcase-report-cell title="Популярные товары">
    <chart :chart-data="chartData"/>
  </showcase-report-cell>
</template>

<script>
import ShowcaseReportCell from '@/components/Showcase/showcase-report-cell'
import Chart from '@/components/Chart'

export default {
  name: 'ReportPopularProducts',
  components: {
    ShowcaseReportCell,
    Chart
  },
  data: () => {
    return {
      chartData: [
        {
          label: 'Цемент',
          value: 15000
        },
        {
          label: 'Арматура',
          value: 12000
        },
        {
          label: 'Утеплитель',
          value: 9000
        }
      ]
    }
  }
}
</script>
